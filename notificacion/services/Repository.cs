using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using notificacion.Configurations.Entities;
using notificacion.dataAcces;
using System.Linq;

namespace notificacion.services
{
    public class Repository : IRepository
    {
        private readonly AppDbContext _context;
        public Repository(AppDbContext context)
        {
            _context = context;
        }
        public Task<IEnumerable<Notification>> Get_Notifications(string id_user)
        {
            IEnumerable<Notification> notis = _context.Notifications.Include(x=>x.User).Where(y=>y.User.Email ==id_user).ToList().AsEnumerable();

            return Task.FromResult(notis);
        }

        public Task<int> Get_notification_notOpen(string id_user)
        {
            var id = _context.Users.Where(x=>x.Email== id_user).First();
           int not_open = _context.Notifications.Where(x=>x.state ==false && x.UserId==id.Id).Count();
            return Task.FromResult(not_open);
        }

        public Task<string> Get_userName_byID(string id_user)
        {
            string user_name = _context.Users.Where(x => x.Id == id_user).Select(y=>y.UserName).First();
            return Task.FromResult(user_name);
        }

        public Task<IEnumerable<IdentityUser>> Get_Users()
        {
            var users = _context.Users.ToList().AsEnumerable();
            return Task.FromResult(users);
        }

        public async Task<int> save_notifications(Notification notification)
        {
            var save_notis = _context.Add(notification);
            var rest = await _context.SaveChangesAsync();
            return rest;
        }
    }
}
