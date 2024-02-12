using DSLearn.Dtos;
using DSLearn.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSLearn.Controllers
{
    [Route("roles")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;

        public RoleController(RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> GetRoles()
        {
            var roles = await _roleManager.Roles.Select(r => r.Name).ToListAsync();
            return Ok(roles);
        }

        [HttpGet("{roleName}/users")]
        public async Task<ActionResult<IEnumerable<string>>> GetUsersInRole(string roleName)
        {
            IdentityRole role = await _roleManager.FindByNameAsync(roleName);

            if (role == null)
            {
                return NotFound($"Role with name {roleName} not found");
            }

            IEnumerable<User> usersInRole = await _userManager.GetUsersInRoleAsync(roleName);

            IEnumerable<UserInfoDTO> result = usersInRole.AsEnumerable().Select(u => new UserInfoDTO(u));
            return Ok(result);
        }
    }
}
