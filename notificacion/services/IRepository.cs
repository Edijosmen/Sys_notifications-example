using Microsoft.AspNetCore.Identity;
using notificacion.Configurations.Entities;

namespace notificacion.services
{
    public interface IRepository
    {
        Task<IEnumerable<Notification>> Get_Notifications(string id_user);
        Task<int> Get_notification_notOpen(string id_user);
        Task<IEnumerable<IdentityUser>> Get_Users();
        Task<int> save_notifications(Notification notification);
        Task<string> Get_userName_byID(string id_user);
    }
}
