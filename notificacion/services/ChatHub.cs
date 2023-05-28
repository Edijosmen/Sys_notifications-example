using Microsoft.AspNetCore.SignalR;
using notificacion.services.Auth;

namespace notificacion.services
{
    public class ChatHub: Hub
    {
        private readonly IAuthManager _authManager;
        private string _token;
        public ChatHub(IAuthManager authManager)
        {
            _authManager=authManager;
        }
        public async Task SendMessage(string userId, string message)
        {
            await Clients.User(userId).SendAsync("ReceiveMessage", userId, message);
        }
        public async void AssociateUser(string authToken)
        {
            // Valida el token de autenticación y obtén el ID de usuario correspondiente
            string userId = await _authManager.ValidateAuthTokenAndGetUserId(authToken);
            _token = userId;
            // Asocia la conexión con el ID de usuario
            var d = Context.ConnectionId;
           await Groups.AddToGroupAsync(Context.ConnectionId, userId);
        }
    }
}
