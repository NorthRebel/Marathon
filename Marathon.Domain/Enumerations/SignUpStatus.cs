namespace Marathon.Domain.Enumerations
{
    /// <remarks> 
    /// Sign up status class should be marked as abstract with protected constructor to encapsulate known enum types
    /// </remarks>
    public class SignUpStatus : Enumeration
    {
        public static SignUpStatus SignedUp = new SignedUpSignUpStatus();
        public static SignUpStatus PaymentConfirmed = new PaymentConfirmedSignUpStatus();
        public static SignUpStatus RaceKitSent = new RaceKitSentSignUpStatus();
        public static SignUpStatus RaceAttended = new RaceAttendedSignUpStatus();

        public SignUpStatus(long id, string name) : base(id, name)
        {
        }

        private class SignedUpSignUpStatus : SignUpStatus
        {
            public SignedUpSignUpStatus() : base(1, "Signed Up")
            {
            }
        }

        private class PaymentConfirmedSignUpStatus : SignUpStatus
        {
            public PaymentConfirmedSignUpStatus() : base(2, "Payment Confirmed")
            {
            }
        }

        private class RaceKitSentSignUpStatus : SignUpStatus
        {
            public RaceKitSentSignUpStatus() : base(3, "Race Kit Sent")
            {
            }
        }

        private class RaceAttendedSignUpStatus : SignUpStatus
        {
            public RaceAttendedSignUpStatus() : base(4, "Race Attended")
            {
            }
        }
    }
}
