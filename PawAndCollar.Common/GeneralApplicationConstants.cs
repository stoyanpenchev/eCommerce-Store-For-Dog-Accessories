namespace PawAndCollar.Common
{
    public static class GeneralApplicationConstants
    {
        public const int ReleaseYear = 2023;
        public const int DefaultPage = 1;
        public const int EntitiesPerPage = 8;

        public const int DefaultPageOrder = 1;
        public const int EntitiesPerPageOrder = 2;

        public const string AdminAreaName = "Admin";
        public const string AdminRoleName = "Administrator";
        public const string DevelopmentAdminEmail = "Admin@abv.bg";

        public const string UserRoleName = "User";
        public const string DevelopmentUserEmail1 = "creator@abv.bg";
		public const string DevelopmentUserEmail2 = "doglover@abv.bg";


        public const string UsersCacheKey = "UsersCacheKey";
        public const string MostBuyedProductsCacheKey = "MostBuyedProductsCacheKey";

        public const int UsersCacheDurationsSec = 10;
        public const int MostBuyedProductsCacheDurationsMinutes = 10;


        public const string OnlineUsersCookieName = "IsOnline";

        public const int LastActivityBeforeOfflineMinutes = 10;
	}
}