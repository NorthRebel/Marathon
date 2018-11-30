using System;
using System.Linq.Expressions;

namespace Marathon.Domain.Enumerations
{
    public class Gender : Enumeration<char, Entities.Gender>
    {
        public static Gender Male = new MaleGender();
        public static Gender Female = new FemaleGender();

        public Gender(char id, string name) : base(id, name)
        {
        }

        private class MaleGender : Gender
        {
            public MaleGender() : base('M', "Male")
            {
            }
        }

        private class FemaleGender : Gender
        {
            public FemaleGender() : base('F', "Female")
            {
            }
        }
    }
}
