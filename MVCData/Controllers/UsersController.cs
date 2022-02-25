using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVCData.Data;
using MVCData.Models;
using MVCData.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly PeopleContext _peopleContext;

        public UsersController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, PeopleContext peopleContext)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _peopleContext = peopleContext;
        }

        public IActionResult Users()
        {
            UsersViewModel usersViewModel = new UsersViewModel();

            usersViewModel.AllUsersList = _userManager.Users.ToList();
            usersViewModel.AllRolesList = _roleManager.Roles.ToList();
            usersViewModel.AllUserRolesList = _peopleContext.UserRoles.ToList();

            return View(usersViewModel);
        }
    }
}
