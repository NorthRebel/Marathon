namespace Marathon.API.Settings
{
    /// <summary>
    /// Configuration parameters of token auth
    /// </summary>
    internal class JWT
    {
        public string SecretKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}
