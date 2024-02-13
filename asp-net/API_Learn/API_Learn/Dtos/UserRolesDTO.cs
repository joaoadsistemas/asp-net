using DSLearn.Entities;
using Microsoft.AspNetCore.Identity;

namespace DSLearn.Dtos
{
    public class UserRolesDTO
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberIsConfirmed { get; set; }
        public IEnumerable<string> Roles { get; set; } = new List<string>();


        public UserRolesDTO(User entity, UserManager<User> userManager)
        {
            this.Id = entity.Id;
            this.UserName = entity.UserName;
            this.Email = entity.Email;
            this.PhoneNumber = entity.PhoneNumber;
            this.PhoneNumberIsConfirmed = entity.PhoneNumberConfirmed;

            Task<IList<string>> rolesTask = userManager.GetRolesAsync(entity);
            rolesTask.Wait();
            this.Roles = rolesTask.Result;
        }
    }
}
