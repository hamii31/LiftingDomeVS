namespace LiftingDome.Areas.Admin.Services
{
	using LiftingDome.Areas.Admin.Services.Interfaces;
	using LiftingDome.Data;
	using LiftingDome.Models;
	using LiftingDome.Web.ViewModels.User;
	using Microsoft.EntityFrameworkCore;
	using System.Collections.Generic;
	using System.Threading.Tasks;

	public class AdministratorService : IAdministratorService
	{
		private readonly LiftingDomeDbContext liftingDomeDbContext;
		public AdministratorService(LiftingDomeDbContext liftingDomeDbContext)
		{
			this.liftingDomeDbContext = liftingDomeDbContext;
		}
		public async Task<IEnumerable<AllUsersViewModel>> GetAllUsersAsync()
		{
			IEnumerable<AllUsersViewModel> allUsers = await this.liftingDomeDbContext
				.Users
				.AsNoTracking()
				.Select(u => new AllUsersViewModel
				{
					Id = u.Id.ToString(),
					FirstName = u.FirstName,
					LastName = u.LastName,
					Email = u.Email,
					PhoneNumber = u.PhoneNumber,
					PostCount = u.Posts.Count()

				}).ToListAsync();

			return allUsers;
		}

		public async Task<int> TotalWorkoutsByCoachEmailAsync(string email)
		{
			Coach? coach = await this.liftingDomeDbContext
				.Coaches
				.FirstAsync(c => c.Email.ToLower() == email.ToLower());

			if (coach == null)
			{
				return 0;
			}

			int totalWorkouts = await this.liftingDomeDbContext
				.Workouts
				.Where(w => w.CoachId.ToString() == coach.Id.ToString())
				.CountAsync();

			return totalWorkouts;
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
	}
}
