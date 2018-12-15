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

        public string SignIn { get; set; }

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
            SignIn = $"{endpoint}/Account/SignIn";
        }
    }
}
