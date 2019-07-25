using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DobApp
{
    public class Pet : FamilyMember
    {
        public string Breed { get; private set; }

        public Pet(string name, string breed, DateTime dob) : base(name, dob)
        {
            this.Breed = breed;
        }

    }
}
