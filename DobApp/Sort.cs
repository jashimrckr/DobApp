using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DobApp
{
    class Sort
    {
    
        public void sortList(List<FamilyMember> FamilyMemberList)
        {
            List<FamilyMember> SortedList = FamilyMemberList.OrderBy(o => o.TotalDays).ToList();
            FamilyMember.Age age = new FamilyMember.Age();
            foreach (var member in SortedList)
            {
                var result = age.calcutateAge(member.Dob);
                Program.printOutput(result.years, result.months, result.days, member.Name, member.Dob);
                Console.WriteLine();
            }
        }
    }
}
