namespace LiftingDome.Services.Tests.ServiceTests
{
    using LiftingDome.Data;
    using LiftingDome.Models;
    public static class DatabaseSeeder
    {
        public static ApplicationUser CoachUser;
        public static ApplicationUser TraineeUser;
        public static Coach Coach;
        public static Workout SoftDeletedWorkout;
        public static Workout Workout;
        public static Workout FreeWorkout;
        public static CoachCertificate Certificate;
        public static ForumPost Post;
        public static ForumPost SoftDeletedPost;
        public static Calculator Meassurment;

        public static void SeedDatabase(LiftingDomeDbContext liftingDomeDbContext)
        {

            CoachUser = new ApplicationUser()
            {
                UserName = "PeshoTheCoach@coaches.com",
                NormalizedUserName = "PESHOTHECOACH@COACHES.COM",
                Email = "PeshoTheCoach@coaches.com",
                NormalizedEmail = "PESHOTHECOACH@COACHES.COM",
                PhoneNumber = "+359881234567",
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

            SoftDeletedWorkout = new Workout()
            {
                Title = "3X3 at 90% for pure strength",
                Description = "The best way for beginner and intermediate strength athletes to build strength.",
                ImageURL = "https://d3h9ln6psucegz.cloudfront.net/wp-content/uploads/2013/08/Best-Set-and-Rep-Scheme-for-Your-Goal.jpg",
                CoachId = CoachUser.Id,
                TraineeId = TraineeUser.Id,
                IsActive = false,
                Category = new WorkoutCategory() { Name = "Powerlifting" }
            };

            Workout = new Workout()
            {
                Title = "The Oldschool 6x6 Protocol for Mass",
                Description = "Take a weight that you could comfortably do 10 reps with (70% of your 1RM) and do 6 sets of 6 reps with as little as 30 seconds rest in between the sets. This protocol builds dense muscle mass at the expense of strength. An advanced athlete should be able to do the protocol with 15 seconds rest in between the sets.",
                ImageURL = "https://www.t-nation.com/wp-content/uploads/2018/06/The-Forgotten-6x6-Protocol.jpeg",
                CoachId = CoachUser.Id,
                TraineeId = TraineeUser.Id,
                Price = 20,
                IsActive = true,
                Category = new WorkoutCategory() { Name = "Bodybuilding" }
            };

            FreeWorkout = new Workout()
            {
                Title = "5/3/1 For Beginners",
                Description = "Monday\r\nSquat – 5/3/1 sets/reps, 5x5 @ First Set Last (FSL)\r\nBench – 5/3/1 sets/reps, 5x5 @ FSL\r\nAssistance work\r\n\r\nWednesday\r\nDeadlift – 5/3/1 sets/reps, 5x5 @ FSL\r\nPress – 5/3/1 sets/reps, 5x5 @ FSL\r\nAssistance work\r\n\r\nFriday\r\nBench – 5/3/1 sets/reps, 5x5 @ FSL\r\nSquat – 5/3/1 sets/reps, 5x5 @ FSL\r\nAssistance work\r\n\r\nUsing the 5/3/1 scheme and the First Set Last Protocol in a full body, 3 times a week strength program.",
                ImageURL = "https://barbend.com/wp-content/uploads/2022/06/Untitled-design-2022-06-09T131654.044.png",
                CoachId = CoachUser.Id,
                TraineeId = TraineeUser.Id,
                Price = 0,
                IsActive = true,
                Category = new WorkoutCategory() { Name = "Powerlifting" }
            };

            Certificate = new CoachCertificate()
            {
                Name = "AFPA"
            };

            Post = new ForumPost()
            {
                Text = "Random gibberish",
                IsActive = true,
                User = TraineeUser,
                Category = new ForumCategory() { Name = "General" }
            };

            SoftDeletedPost = new ForumPost()
            {
                Text = "Random gibberish but deleted",
                IsActive = false,
                User = CoachUser,
                Category = new ForumCategory() { Name = "General" }
            };

            Meassurment = new Calculator()
            {
                Id = 2222,
                Name = "Kg"
            };

            liftingDomeDbContext.Users.Add(CoachUser);
            liftingDomeDbContext.Users.Add(TraineeUser);
            liftingDomeDbContext.Coaches.Add(Coach);
            liftingDomeDbContext.Workouts.Add(SoftDeletedWorkout);
            liftingDomeDbContext.Workouts.Add(Workout);
            liftingDomeDbContext.Workouts.Add(FreeWorkout);
            liftingDomeDbContext.Certificates.Add(Certificate);
            liftingDomeDbContext.Posts.Add(Post);
            liftingDomeDbContext.Posts.Add(SoftDeletedPost);
            liftingDomeDbContext.CalculatorMeassurments.Add(Meassurment);

            liftingDomeDbContext.SaveChanges();
        }
    }
}
