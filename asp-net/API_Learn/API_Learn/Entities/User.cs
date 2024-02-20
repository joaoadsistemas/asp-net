using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace DSLearn.Entities
{

    public class User : IdentityUser
    {

        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }

        public IEnumerable<Notification> Notifications { get; set; } 

        public IEnumerable<Offer> Offers { get; set; }

        public IEnumerable<Enrollment> Enrollments { get; set; }


        public IEnumerable<Reply> ReplyLikes { get; set; }
        public IEnumerable<Topic> TopicLikes { get; set; }
    }
}
