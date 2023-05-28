using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using notificacion.Models;
using notificacion.services;
using notificacion.services.Auth;

namespace notificacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IMapper _Imapper;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IAuthManager _AuthManage;
        private readonly IRepository _Repository;
        public AccountsController(IMapper Imapper, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IAuthManager AuthManage, IRepository repository)
        {
            _Imapper = Imapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _AuthManage = AuthManage;
            _Repository = repository;
        }

        [HttpPost]
        [Route("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterUserDto user)
        {
            if (ModelState.IsValid)
            {
                var userIdentity = _Imapper.Map<IdentityUser>(user);
                userIdentity.UserName = user.Email;
               
                var result = await _userManager.CreateAsync(userIdentity,user.Password);

                if (result.Succeeded)
                {
                    // Aquí se podría enviar un correo electrónico al usuario con el enlace de confirmación de correo electrónico
                }
                await _userManager.AddToRoleAsync(userIdentity,user.Role);
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return Ok();
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] UserDto user)
        {
            string token = String.Empty;
            if (ModelState.IsValid)
            {
                var userIdentity = _Imapper.Map<IdentityUser>(user);
                userIdentity.UserName = user.Email;

                var result = await _AuthManage.ValidateUser(user);

                if (!result)
                {
                    // Aquí se podría enviar un correo electrónico al usuario con el enlace de confirmación de correo electrónico
                    return BadRequest();
                }
                 token = await _AuthManage.CreatToken();
            }

            return Ok(new {token=token});
        }
        [Authorize]
        [HttpGet]
        [Route("prueba")]
        public async Task<IActionResult> prueba()
        {
            return Ok();
        }

        [HttpGet]
        [Route("Get_User")]
        public async Task<IActionResult> Get_users()
        {
            var result = await _Repository.Get_Users();
            return Ok(result);
        }
    }
}
