using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DobApp
{
    public class Person : FamilyMember
    {
        public string Profession { get; private set; }

        public Person(string name, string profession, DateTime dob) : base(name, dob)
        {
            this.Profession = profession;
        }
    }
}
