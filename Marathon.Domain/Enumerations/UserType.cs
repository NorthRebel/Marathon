namespace Marathon.Domain.Enumerations
{
    public class UserType : Enumeration
    {
        public static UserType Administrator = new AdministratorUserType();
        public static UserType Coordinator = new CoordinatorUserType();
        public static UserType Runner = new RunnerUserType();

        public UserType(long id, string name) : base(id, name)
        {
        }

        private class AdministratorUserType : UserType
        {
            public AdministratorUserType() : base(1, "Administrator")
            {
            }
        }

        private class CoordinatorUserType : UserType
        {
            public CoordinatorUserType() : base(2, "Coordinator")
            {
            }
        }

        private class RunnerUserType : UserType
        {
            public RunnerUserType() : base(3, "Runner")
            {
            }
        }
    }
}
