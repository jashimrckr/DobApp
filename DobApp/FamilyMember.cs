using System;
using System.Collections.Generic;
using System.Linq;

namespace DobApp
{
    public abstract class FamilyMember
    {
        public string Name { get; private set; }
        public DateTime Dob { get; protected set; }
        public int TotalDays { get; protected set; }
        public Age Age { get; protected set; }

        public FamilyMember(string name, DateTime dob)
        {
            this.Name = name;
            this.Dob = dob;
            this.TotalDays = (DateTime.Now - dob).Days;
            this.Age = new Age(dob);
        }

        public static List<FamilyMember> SortMembers(List<FamilyMember> familyMemberList)
        {
            List<FamilyMember> sortedList = familyMemberList.OrderBy(o => o.TotalDays).ToList();
            return sortedList;
        }
    } 
}

