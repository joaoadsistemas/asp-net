using DSLearn.Entities;
using Microsoft.AspNetCore.Identity;

namespace DSLearn.Dtos
{
    public class UserAllInformationsDTO
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberIsConfirmed { get; set; }

        public IEnumerable<EnrollmentDTO> Offers { get; set; } = new List<EnrollmentDTO>();
        public IEnumerable<NotificationDTO> Notifications { get; set; } = new List<NotificationDTO>();



        public UserAllInformationsDTO(User entity)
        {
            this.Id = entity.Id;
            this.UserName = entity.UserName;
            this.Email = entity.Email;
            this.PhoneNumber = entity.PhoneNumber;
            this.PhoneNumberIsConfirmed = entity.PhoneNumberConfirmed;
            this.Offers = entity.Enrollments != null ? entity.Enrollments.AsEnumerable().Select(e => new EnrollmentDTO(e)) : null;
            this.Notifications = entity.Notifications != null ? entity.Notifications.AsEnumerable().Select(n => new NotificationDTO(n)) : null; ;
        }

    }
}
