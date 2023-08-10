namespace LiftingDome.Infrastructure.Middleware
{
	using LiftingDome.Infrastructure.Extensions;
	using Microsoft.AspNetCore.Http;
	using Microsoft.Extensions.Caching.Memory;
	using System.Collections.Concurrent;
	using static Common.GeneralApplicationConstants;
	public class OnlineUsersMiddleware
	{
		private readonly RequestDelegate next;
		private readonly string cookieName;
		private readonly int lastActivityMinutes;

		private static readonly ConcurrentDictionary<string, bool> AllKeys = new ConcurrentDictionary<string, bool>();

		public OnlineUsersMiddleware(RequestDelegate next,
			string cookieName = OnlineUsersCookieName,
			int lastActivityMinutes = LastActivityMinutesBeforeOffline)
		{
			this.next = next;
			this.cookieName = cookieName;
			this.lastActivityMinutes = lastActivityMinutes;
		}

		public Task InvokeAsync(HttpContext context, IMemoryCache memoryCache)
		{
			if (context.User.Identity?.IsAuthenticated ?? false)
			{
				if (!context.Request.Cookies.TryGetValue(this.cookieName, out string userId))
				{
					userId = context.User.GetId()!;

					context.Response.Cookies.Append(this.cookieName, userId, new CookieOptions()
					{
						HttpOnly = true,
						MaxAge = TimeSpan.FromDays(30)
					});
				}

				memoryCache.GetOrCreate(userId, cacheEntry =>
				{
					if (!AllKeys.TryAdd(userId, true))
					{
						cacheEntry.AbsoluteExpiration = DateTimeOffset.MinValue;
					}
					else
					{
						cacheEntry.SlidingExpiration = TimeSpan.FromMinutes(this.lastActivityMinutes);
						cacheEntry.RegisterPostEvictionCallback(this.RemoveKeyWhenExpired);
					}

					return string.Empty;
				});
			}
			else
			{
				if (context.Request.Cookies.TryGetValue(this.cookieName, out string userId))
				{
					if (!AllKeys.TryRemove(userId, out _))
					{
						AllKeys.TryUpdate(userId, false, true);
					}

					context.Response.Cookies.Delete(this.cookieName);
				}
			}

			return this.next(context);
		}

		public static bool CheckIfUserIsOnline(string userId)
		{
			bool value = AllKeys.TryGetValue(userId.ToLower(), out bool success);

			return success && value;
		}

		private void RemoveKeyWhenExpired(object key, object value, EvictionReason evictionReason, object state)
		{
			string keyToString = key.ToString()!;

			if (!AllKeys.TryRemove(keyToString, out _))
			{
				AllKeys.TryUpdate(keyToString, false, true);
			}
		}
	}
}
