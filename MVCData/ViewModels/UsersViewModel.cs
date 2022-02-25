using Microsoft.AspNetCore.Identity;
using MVCData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData.ViewModels
{
    public class UsersViewModel
    {
        public List<ApplicationUser> AllUsersList { get; set; }
        public List<IdentityRole> AllRolesList { get; set; }
        public List<IdentityUserRole<string>> AllUserRolesList { get; set; }
    }
}
