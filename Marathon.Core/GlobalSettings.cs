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

        public string UserSignIn { get; set; }
        public string UserSignUp { get; set; }
        public string RunnerSignUp { get; set; }

        public string AllCountries { get; set; }
        public string AllGenders { get; set; }

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
            RunnerSignUp = $"{endpoint}/Runner/SignUp";

            AllCountries = $"{endpoint}/Countries/All";
            AllGenders = $"{endpoint}/Genders/All";
        }
    }
}
