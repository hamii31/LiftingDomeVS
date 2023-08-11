namespace LiftingDome.Services.Tests
{
	using LiftingDome.Data;
	using LiftingDome.Models;
	public static class DatabaseSeeder
	{
		public static ApplicationUser CoachUser;
		public static ApplicationUser TraineeUser;
		public static Coach Coach;

		public static void SeedDatabase(LiftingDomeDbContext liftingDomeDbContext)
		{ 

			CoachUser = new ApplicationUser()
			{
				UserName = "PeshoTheCoach@coaches.com",
				NormalizedUserName = "PESHOTHECOACH@COACHES.COM",
				Email = "PeshoTheCoach@coaches.com",
				NormalizedEmail = "PESHOTHECOACH@COACHES.COM",
				EmailConfirmed = false,
				PasswordHash = "8D969EEF6ECAD3C29A3A629280E686CF0C3F5D5A86AFF3CA12020C923ADC6C92",
				SecurityStamp = "c5d64406-65eb-46ab-8720-24e73fded2ed",
				ConcurrencyStamp = "9f0e7eea-737a-494e-a859-531d43642695",
				TwoFactorEnabled = false,
				FirstName = "Petur",
				LastName = "Petrov"
			};

			TraineeUser = new ApplicationUser()
			{
				UserName = "GoshoTheTrainee@trainees.com",
				NormalizedUserName = "GOSHOTHETRAINEE@TRAINEES.COM",
				Email = "GoshoTheTrainee@trainees.com",
				NormalizedEmail = "GOSHOTHETRAINEE@TRAINEES.COM",
				EmailConfirmed = false,
				PasswordHash = "8D969EEF6ECAD3C29A3A629280E686CF0C3F5D5A86AFF3CA12020C923ADC6C92",
				SecurityStamp = "ba3f2b7f-88c5-4159-89a0-08cbb26a1068",
				ConcurrencyStamp = "8634241a-c95a-4f68-bf04-369c81384ac0",
				TwoFactorEnabled = false,
				FirstName = "Georgi",
				LastName = "Turboto"
			};

			Coach = new Coach()
			{
				PhoneNumber = "+359881234567",
				CertificateName = "AFPA",
				User = CoachUser,
				Email = "PeshoTheCoach@coaches.com",
				FirstName = "Petur",
				LastName = "Petrov"
			};

			liftingDomeDbContext.Users.Add(CoachUser);
			liftingDomeDbContext.Users.Add(TraineeUser);
			liftingDomeDbContext.Coaches.Add(Coach);

			liftingDomeDbContext.SaveChanges();
		}
	}
}
