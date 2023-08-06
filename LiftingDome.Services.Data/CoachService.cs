namespace LiftingDome.Services.Data
{
    using LiftingDome.Data;

    using LiftingDome.Models;

    using LiftingDome.Services.Data.Interfaces;

    using LiftingDome.Web.ViewModels.Coach;

    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;

    public class CoachService : ICoachService
    {
        private readonly LiftingDomeDbContext liftingDomeDbContext;
        public CoachService(LiftingDomeDbContext liftingDomeDbContext)
        {
            this.liftingDomeDbContext = liftingDomeDbContext;
        }

		public async Task<bool> CoachExistsByPhoneNumberAsync(string phoneNumber)
        {
            bool result = await this.liftingDomeDbContext.Coaches.AnyAsync(c => c.PhoneNumber == phoneNumber);

            return result;
        }

        public async Task<bool> CoachExistsByUserIdAsync(string userId)
        {
            bool result = await this.liftingDomeDbContext.Coaches.AnyAsync(x => x.UserId.ToString() == userId);
            
            return result;
        }

        public async Task Create(string userId, CoachFormModel model)
        {
            Coach coach = new Coach()
            {
                PhoneNumber = model.PhoneNumber,
                Email = CoachFormModel.Email,
                UserId = Guid.Parse(userId),
                CertificateName = model.Certification
            };

            await this.liftingDomeDbContext.Coaches.AddAsync(coach);
            await this.liftingDomeDbContext.SaveChangesAsync();
        }

		public async Task<IEnumerable<AllCoachesViewModel>> GetAllCoachesAsync()
		{
            IEnumerable<AllCoachesViewModel> allCoaches = await this.liftingDomeDbContext
                .Coaches
                .AsNoTracking()
                .Select(c => new AllCoachesViewModel()
                {
                    Id = c.Id.ToString(),
                    ImageURL = c.ImageURL,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    Email = c.Email,
                    Phone = c.PhoneNumber,
                    CertificateName = c.CertificateName,
                    WorkoutCount = c.CreatedWorkouts.Count()

                }).ToListAsync();

            return allCoaches;
		}

		public async Task<string?> GetCoachIdByUserIdAsync(string userId)
		{
            Coach? coach = await this.liftingDomeDbContext
                .Coaches
                .FirstOrDefaultAsync(c => c.UserId.ToString() == userId);

            if (coach == null)
            {
                return null;
            }

            return coach.Id.ToString();
		}

		public async Task<string> GetCoachNameBYCoachEmailAsync(string coachEmail)
		{
			Coach? coach = await this.liftingDomeDbContext
                .Coaches
                .FirstAsync(w => w.Email == coachEmail);

            if(coach == null)
            {
                return string.Empty;
            }

            return coach.FirstName + " " + coach.LastName;
		}

		public async Task<string> GetCoachNameByCoachIdAsync(string userId)
		{
			Coach? coach = await this.liftingDomeDbContext
                .Coaches
                .FirstOrDefaultAsync(c => c.UserId.ToString() == userId);

            if (coach == null)
            {
                return string.Empty;
            }

            return coach.Email.ToString();
		}

		public async Task<bool> HasWorkoutWithIdAsync(string userId, string workoutId)
        {
            Coach? coach = await this.liftingDomeDbContext
                .Coaches
                .Include(w => w.CreatedWorkouts)
                .FirstOrDefaultAsync(c => c.UserId.ToString() == userId);
            if (coach == null)
            {
                return false;
            }
            
            return coach.CreatedWorkouts.Any(w => w.Id.ToString() == workoutId.ToLower());
        }

		public async Task UpdateInfo(CoachFormModel model, string userId)
		{
			Coach? coach = await this.liftingDomeDbContext
                .Coaches
                .FirstAsync(c => c.UserId.ToString() == userId);

            coach.CertificateName = model.Certification;
            coach.PhoneNumber = model.PhoneNumber;
            coach.ImageURL = model.ImageURL;
			coach.FirstName = model.FirstName;
			coach.LastName = model.LastName;
		
            

			await this.liftingDomeDbContext.SaveChangesAsync();
		}
	}
}
