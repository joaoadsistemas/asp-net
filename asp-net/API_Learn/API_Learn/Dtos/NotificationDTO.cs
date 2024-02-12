using DSLearn.Dtos;
using DSLearn.Entities;
using Microsoft.AspNetCore.Identity;

public class NotificationDTO
{

    public int Id { get; set; }
    public string Text { get; set; }
    public DateTime Moment { get; set; }
    public bool Read { get; set; } = false;
    public string Route { get; set; }

    public UserInfoDTO User { get; set; }

    public NotificationDTO(Notification notification)
    {
        this.Id = notification.Id;
        this.Text = notification.Text;
        this.Moment = notification.Moment;
        this.Route = notification.Route;
        this.Read = notification.Read;
        this.User = notification.User != null ? new UserInfoDTO(notification.User) : null;

    }
}
