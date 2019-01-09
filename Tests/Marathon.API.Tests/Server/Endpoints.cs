namespace Marathon.API.Tests.Server
{
    internal static class Endpoints
    {
        public static string UserSignIn => "/Account/SignIn";
        public static string UserSignUp => "/Account/SignUp";

        private static string RunnerId => "/Runner/Id";
        public static string GetRunnerIdRoute(int userId) => $"{RunnerId}/{userId}";
        public static string RunnerSignUp => "/Runner/SignUp";
        public static string AllCountries => "/Countries/All";
        public static string AllGenders => "/Genders/All";

        public static string AllRaceKits => "/RaceKit/All";

        public static string SignUpToMarathon => "/Marathon/SignUp";
        public static string EventTypes => "/Marathon/EventTypes";


        public static string AllCharities => "/Charities/All";
        private static string AboutCharity => "/Charities/About";

        public static string GetAboutCharityRoute(int id) => $"{AboutCharity}/{id}";
    }
}
