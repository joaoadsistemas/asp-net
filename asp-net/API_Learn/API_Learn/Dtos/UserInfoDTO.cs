using DSLearn.Entities;
using Microsoft.AspNetCore.Identity;

namespace DSLearn.Dtos
{
    public class UserInfoDTO
    {

        public string Id { get; set; }
        public string UserName { get; set; }


        public UserInfoDTO(User entity)
        {
            this.Id = entity.Id;
            this.UserName = entity.UserName;
        }


    }
}
