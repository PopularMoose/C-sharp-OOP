using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo
{
    public class Citizen : IPerson, IBirthable, IIdentifiable 
    {
        public Citizen(string name, int age, string birthdate, string id)
        {
            Name = name;
            Age = age;
            Birthdate = birthdate;
            Id = id;
        }

        public string Name { get; set ; }
        public int Age { get ; set; }
        public string Birthdate { get ; set ; }
        public string Id { get; set ; }
    }
}
