﻿namespace LiftingDome.Common
{
    public static class GeneralApplicationConstants
    {
        public const int ReleaseYear = 2023;

        public const int DefaultPageIndex = 1;
        public const int EntitiesPerPage = 3;

        public const int DefaultMeassurmentIndex = 1;

        public const string AdminAreaName = "Admin";
        public const string AdminRoleName = "Admin";
        public const string DevelopmentAdminEmail = "Admin@liftingdome.bg";

        public const string UserCacheKey = "UserCache";
        public const int UserCacheDurationMinutes = 5;

        public const string OnlineUsersCookieName = "UserIsOnline";
        public const int LastActivityMinutesBeforeOffline = 10;
    }
}
