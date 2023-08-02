namespace LiftingDome.Services.Data
{
    using LiftingDome.Data;

    using LiftingDome.Models;

    using LiftingDome.Services.Data.Interfaces;

    using LiftingDome.Web.ViewModels.Coach;

    using Microsoft.EntityFrameworkCore;

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

        public async Task Create(string userId, BecomeCoachFormModel model)
        {
            Coach coach = new Coach()
            {
                PhoneNumber = model.PhoneNumber,
                Email = BecomeCoachFormModel.Email,
                UserId = Guid.Parse(userId)
            };

            await this.liftingDomeDbContext.Coaches.AddAsync(coach);
            await this.liftingDomeDbContext.SaveChangesAsync();
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

	}
}
