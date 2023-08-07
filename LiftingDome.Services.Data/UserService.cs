namespace LiftingDome.Services.Data
{
	using LiftingDome.Data;
	using LiftingDome.Models;
	using LiftingDome.Services.Data.Interfaces;
	using Microsoft.EntityFrameworkCore;
	using System.Collections.Generic;
	using System.Threading.Tasks;

	public class UserService : IUserService
	{
		private readonly LiftingDomeDbContext liftingDomeDbContext;
		public UserService(LiftingDomeDbContext liftingDomeDbContext)
		{
			this.liftingDomeDbContext = liftingDomeDbContext;
		}

		public async Task<IEnumerable<string>> AllUserNamesAsync()
		{
			IEnumerable<string> allNames = await this.liftingDomeDbContext
				.Users
				.Select(c => c.Email)
				.ToArrayAsync();

			return allNames;
		}

		public async Task<string> GetFullNameByEmailAsync(string email)
		{
			ApplicationUser? user = await this.liftingDomeDbContext
				.Users
				.FirstOrDefaultAsync(u => u.Email == email);

			if (user == null)
			{
				return string.Empty;
			}

			return user.FirstName + " " + user.LastName;

		}

		public async Task<string?> GetUserEmailByUserIdAsync(string userId)
		{
			ApplicationUser? user = await this.liftingDomeDbContext
			   .Users
			   .FirstOrDefaultAsync(u => u.Id.ToString() == userId);

			if (user == null)
			{
				return null;
			}

			return user.Email.ToString();
		}

		public async Task<int> TotalWorkoutsByUserIdAsync(string userId)
		{
			ApplicationUser? user = await this.liftingDomeDbContext
				.Users
				.Include(w => w.AddedWorkouts)
				.FirstOrDefaultAsync(u => u.Id.ToString() == userId);

			if (user == null)
			{
				return 0;
			}

			return user.AddedWorkouts.Count();
		}

		public async Task<bool> UserExistsByUserIdAsync(string userId)
		{
			bool result = await this.liftingDomeDbContext.Users.AnyAsync(x => x.Id.ToString() == userId);

			return result;
		}

		public async Task<bool> UserExistsByUserNameAsync(string userName)
		{
			bool result = await this.liftingDomeDbContext.Users.AnyAsync(x => x.Email.ToLower() == userName.ToLower());

			return result;
		}

		public async Task<bool> UserHasWorkoutsByUserIdAsync(string userId)
		{
			ApplicationUser? user = await this.liftingDomeDbContext
			   .Users
			   .Include(w => w.AddedWorkouts)
			   .FirstOrDefaultAsync(u => u.Id.ToString() == userId);

			if (user == null)
			{
				return false;
			}

			return user.AddedWorkouts.Any();
		}

		public async Task<bool> UserHasWorkoutsWithId(string userId, string workoutId)
		{
			ApplicationUser? user = await this.liftingDomeDbContext
		   .Users
		   .Include(w => w.AddedWorkouts)
		   .FirstOrDefaultAsync(u => u.Id.ToString() == userId);

			if (user == null)
			{
				return false;
			}

			return user.AddedWorkouts.Any(w => w.Id.ToString() == workoutId.ToLower());
		}
	}
}
