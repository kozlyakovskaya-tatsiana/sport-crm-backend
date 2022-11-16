using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using SelfFit.Application;
using SelfFit.Identity.Authorization;
using SelfFit.Identity.Entities;
using SelfFit.Identity.Settings;

namespace SelfFit.Identity
{
    public class SelfFitAuthenticationDbSeeder
    {
        private readonly UserManager<SelfFitIdentityUser> _userManager;
        private readonly RoleManager<SelfFitRole> _roleManager;
        private readonly DefaultUserSettings _defaultUserSettings;
        private readonly ISelfFitDbContext _selfFitDbContext;

        public SelfFitAuthenticationDbSeeder(
            UserManager<SelfFitIdentityUser> userManager,
            RoleManager<SelfFitRole> roleManager,
            IOptions<DefaultUserSettings> defaultUserSettings,
            ISelfFitDbContext selfFitDbContext)
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
                    var user = new SelfFitIdentityUser
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
