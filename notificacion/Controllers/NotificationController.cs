using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using notificacion.Configurations.Entities;
using notificacion.Models;
using notificacion.services;
using notificacion.services.Auth;

namespace notificacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly IRepository _Repository;
        private readonly IAuthManager _authManager;
        private readonly IMapper _Impper;
        private readonly IHubContext<ChatHub> _hubContext;
        public NotificationController(IRepository repository,IAuthManager authManager,IMapper mapper, IHubContext<ChatHub> hubContext)
        {
            _Repository = repository;
            _authManager = authManager;
            _Impper = mapper;
            _hubContext = hubContext;
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetNotifications()
        {
            string id_user;
            var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            try
            {
               id_user = await _authManager.ValidateAuthTokenAndGetUserId(token);
            }
            catch (Exception)
            {
                return Unauthorized();
            }
            var result = await _Repository.Get_Notifications(id_user) ?? Enumerable.Empty<Notification>();
            return result.Any() ? Ok(result) : BadRequest();
        }
        [Authorize]
        [HttpGet]
        [Route("notopen")]
        public async Task<IActionResult> Get_notification_notOpen()
        {
            string id_user;
            var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            try
            {
                id_user = await _authManager.ValidateAuthTokenAndGetUserId(token);
            }
            catch (Exception)
            {
                return Unauthorized();
            }
                var result = await _Repository.Get_notification_notOpen(id_user);
            return result>=0 ? Ok(result) : BadRequest();
        }
        [HttpPost]
        public async Task<IActionResult> add_notifications( SetNotification notis)
        {
            string user_name = await _Repository.Get_userName_byID(notis.UserId);
          
            
            Notification notification = _Impper.Map<Notification>(notis);
            var result = await _Repository.save_notifications(notification);
            var n_notifications = await _Repository.Get_notification_notOpen(user_name);
            await _hubContext.Clients.Group(user_name).SendAsync("ReceiveMessage", n_notifications);
            return result>0 ? Ok("registro guardado!") : BadRequest();
        }
    }
}
