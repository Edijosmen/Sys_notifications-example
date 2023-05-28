using Microsoft.AspNetCore.Identity;

namespace notificacion.Configurations.Entities
{
    public class Notification
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public Boolean state { get; set; }
        public string UserId { get; set; }
        public IdentityUser User { get; set; }
    }
}
