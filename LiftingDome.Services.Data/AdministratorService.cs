namespace LiftingDome.Services.Data
{
	using LiftingDome.Data;
	using LiftingDome.Services.Data.Interfaces;
	using LiftingDome.Web.ViewModels.Admin;
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
					PostCount = u.Posts.Count()

				}).ToListAsync();

			return allUsers;
		}
	}
}
