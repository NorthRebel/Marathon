namespace Marathon.Core
{
    public class GlobalSettings
    {
        public const string DefaultEndpoint = "https://localhost:5000";

        public static GlobalSettings Instance { get; } = new GlobalSettings();

        private string _baseIdentityEndpoint;

        public GlobalSettings()
        {
            BaseIdentityEndpoint = DefaultEndpoint;
        }

        #region Routes

        public string UserSignIn { get; private set; }
        public string UserSignUp { get; private set; }

        private string RunnerId { get; set; }
        public string GetRunnerIdRoute(int userId) => $"{RunnerId}/{userId}";
        public string RunnerSignUp { get; private set; }

        public string AllCountries { get; private set; }
        public string AllGenders { get; private set; }

        public string AllRaceKits { get; private set; }

        public string SignUpToMarathon { get; private set; }
        public string EventTypes { get; private set; }


        public string AllCharities { get; private set; }
        private string AboutCharity { get; set; }

        public string GetAboutCharityRoute(int id) => $"{AboutCharity}/{id}";

        #endregion

        public string BaseIdentityEndpoint
        {
            get => _baseIdentityEndpoint;
            set
            {
                _baseIdentityEndpoint = value;
                UpdateEndpoint(_baseIdentityEndpoint);
            }
        }

        private void UpdateEndpoint(string endpoint)
        {
            UserSignIn = $"{endpoint}/Account/SignIn";
            UserSignUp = $"{endpoint}/Account/SignUp";

            RunnerId = $"{endpoint}/Runner/Id";
            RunnerSignUp = $"{endpoint}/Runner/SignUp";

            AllCountries = $"{endpoint}/Countries/All";
            AllGenders = $"{endpoint}/Genders/All";

            AllRaceKits = $"{endpoint}/RaceKit/All";

            EventTypes = $"{endpoint}/Marathon/EventTypes";
            SignUpToMarathon = $"{endpoint}/Marathon/SignUp";

            AllCharities = $"{endpoint}/Charities/All";
            AboutCharity = $"{endpoint}/Charities/About";
        }
    }
}
