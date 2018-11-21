using System.Security;

namespace Marathon.Application.Sponsorship.Commands.SponsorshipRunner.Models
{
    /// <summary>
    /// Credentials of bank card
    /// </summary>
    public sealed class CardCredentialsViewModel
    {
        public SecureString Number { get; set; }
        public SecureString CVC { get; set; }
        public SecureString Holder { get; set; }
        public SecureString MonthValidity { get; set; }
        public SecureString YearValidity { get; set; }
    }
}
