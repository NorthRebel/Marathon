namespace Marathon.Domain.Enumerations
{
    public class UserType : Enumeration<char>
    {
        public static UserType Administrator = new AdministratorUserType();
        public static UserType Coordinator = new CoordinatorUserType();
        public static UserType Runner = new RunnerUserType();

        public UserType(char id, string name) : base(id, name)
        {
        }

        private class AdministratorUserType : UserType
        {
            public AdministratorUserType() : base('A', "Administrator")
            {
            }
        }

        private class CoordinatorUserType : UserType
        {
            public CoordinatorUserType() : base('C', "Coordinator")
            {
            }
        }

        private class RunnerUserType : UserType
        {
            public RunnerUserType() : base('R', "Runner")
            {
            }
        }
    }
}
