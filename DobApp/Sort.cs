using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DobApp
{
    class Sort
    {   
        public List<FamilyMember> sortMembers(List<FamilyMember> FamilyMemberList)
        {
            List<FamilyMember> sortedList = FamilyMemberList.OrderBy(o => o.TotalDays).ToList();
            return sortedList;
            
        }
    }
}
