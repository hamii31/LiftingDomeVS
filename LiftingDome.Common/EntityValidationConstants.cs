namespace LiftingDome.Common
{
    public static class EntityValidationConstants
    {
        public static class WorkoutCategory 
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 50;
        }
        public static class Workout
        {
            public const int TitleMinLength = 10;
            public const int TitleMaxLength = 50;

            public const int DescriptionMinLength = 50;
            public const int DescriptionMaxLength = 1000;

            public const int ImageURLMaxLength = 2048;

            public const string PriceMinValue = "0";
            public const string PriceMaxValue = "1000";
        }
        public static class Coach
        {
            public const int NumberMinLength = 7;
            public const int NumberMaxLength = 15;

            public const int EmailMinLength = 3;
            public const int EmailMaxLength = 254;
        }
        public static class Calculator
        {
            public const int NameMaxLength = 10;
        }
        public static class Post
        {
            public const int TextMaxLength = 300;
        }
        public static class User
        {
            public const int PasswordMinLength = 6;
            public const int PasswordMaxLength = 100;

            public const int FirstNameMinLength = 1;
            public const int FirstNameMaxLength = 15;

            public const int LastNameMinLength = 1;
            public const int LastNameMaxLength = 15;
        }
    }
}
