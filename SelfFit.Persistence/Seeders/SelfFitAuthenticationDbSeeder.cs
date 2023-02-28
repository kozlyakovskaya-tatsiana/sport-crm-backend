using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using SelfFit.Application;
using SelfFit.Domain.Entities;
using SelfFit.Identity.Authorization;
using SelfFit.Identity.Entities;
using SelfFit.Identity.Settings;

namespace SelfFit.Persistence.Seeders
{
    public class SelfFitAuthenticationDbSeeder
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly DefaultUserSettings _defaultUserSettings;
        private readonly SelfFitDbContext _selfFitDbContext;

        public SelfFitAuthenticationDbSeeder(
            UserManager<User> userManager,
            RoleManager<Role> roleManager,
            IOptions<DefaultUserSettings> defaultUserSettings,
            SelfFitDbContext selfFitDbContext)
        {
            _userManager=userManager;
            _roleManager=roleManager;
            _defaultUserSettings=defaultUserSettings.Value;
            _selfFitDbContext = selfFitDbContext;
        }

        public async Task SeedRolesAndUsersAsync()
        {
            await _selfFitDbContext.MigrateAsync();
            await SeedRolesAsync();
            await SeedUsersAsync();
        }

        private async Task SeedRolesAsync()
        {
            if (!_roleManager.Roles.Any(role => role.Name == UserRoles.Admin))
            {
                await _roleManager.CreateAsync(new Role(UserRoles.Admin));
            }
            if (!_roleManager.Roles.Any(role => role.Name == UserRoles.Instructor))
            {
                await _roleManager.CreateAsync(new Role(UserRoles.Instructor));
            }
        }
        private async Task SeedUsersAsync()
        {
            if (!_userManager.Users.Any())
            {
                foreach (var defaultUser in _defaultUserSettings.DefaultUsers)
                {
                    var user = new User
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
