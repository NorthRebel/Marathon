namespace Marathon.Domain.Enumerations
{
    public class Gender : Enumeration
    {
        public static Gender Male = new MaleGender();
        public static Gender Female = new FemaleGender();

        public Gender(long id, string name) : base(id, name)
        {
        }

        private class MaleGender : Gender
        {
            public MaleGender() : base(1, "Male")
            {
            }
        }

        private class FemaleGender : Gender
        {
            public FemaleGender() : base(2, "Female")
            {
            }
        }
    }
}
