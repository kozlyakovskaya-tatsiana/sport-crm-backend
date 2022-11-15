using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using SelfFit.Application.Authorization;
using SelfFit.Application.Settings;
using SelfFit.Domain.Entities;

namespace SelfFit.Persistence
{
    public class SelfFitDbSeeder
    {
        private readonly UserManager<SelfFitUser> _userManager;
        private readonly RoleManager<SelfFitRole> _roleManager;
        private readonly DefaultUserSettings _defaultUserSettings;

        public SelfFitDbSeeder(UserManager<SelfFitUser> userManager, RoleManager<SelfFitRole> roleManager, DefaultUserSettings defaultUserSettings)
        {
            _userManager=userManager;
            _roleManager=roleManager;
            _defaultUserSettings=defaultUserSettings;
        }

        public async Task SeedAsync()
        {
            await SeedRolesAsync();
            await SeedUsersAsync();
        }

        private async Task SeedRolesAsync()
        {
            if (!_roleManager.Roles.Any(role => role.Name == UserRoles.Admin))
            {
                await _roleManager.CreateAsync(new SelfFitRole(UserRoles.Admin));
            }
            if (!_roleManager.Roles.Any(role => role.Name == UserRoles.Instructor))
            {
                await _roleManager.CreateAsync(new SelfFitRole(UserRoles.Instructor));
            }
        }
        private async Task SeedUsersAsync()
        {
            if (!_userManager.Users.Any())
            {
                foreach (var defaultUser in _defaultUserSettings.DefaultUsers)
                {
                    var user = new SelfFitUser
                    {
                        Email = defaultUser.Email,
                        UserName = defaultUser.Email
                    };
                    await _userManager.CreateAsync(user, defaultUser.Password);
                    await _userManager.AddToRoleAsync(user, defaultUser.Role);
                }
            }
        }
    }
}
