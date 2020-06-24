using BusinessCard.Data.Entities.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualBasic;
using System.Threading.Tasks;

namespace BusinessCard.Services.Roles
{
    public class RoleService : IRoleService
    {
        public RoleService()
        {
          
        }

        public static async Task CreateRolesAsync(RoleManager<RoleEntity> roleManager)
        {
            var roles = new RoleEntity[] {
                new RoleEntity{ Name = "SuperAdmin"},
                new RoleEntity{ Name = "Admin"},
                new RoleEntity{ Name = "User"}
            };

            foreach (var role in roles)
            {
                await roleManager.CreateAsync(role);
            }
        }
    }
}
