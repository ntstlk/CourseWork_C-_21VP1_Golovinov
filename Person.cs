using System;

namespace CourseWork.Source.Entities
{
    internal class Person
    {
        //primary key in database   
        public string PhoneNumber { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }  = DateTime.MinValue;
        public Roles Role { get; set; }

        //roles of persons, matches to DBtables
        public enum Roles
        {
            Poet,
            Critic,
        }
     
    }
}
