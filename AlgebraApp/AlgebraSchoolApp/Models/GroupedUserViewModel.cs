using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlgebraSchoolApp.Models
{
    public class GroupedUserViewModel
    {
        public List<EmployeeViewModel> Users { get; set; }
        public List<EmployeeViewModel> Admins { get; set; }

    }
}