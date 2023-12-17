using AleffGroup.Application.Interfaces;
using AleffGroup.Domain.Interfaces.Services;
using AleffGroup.Infra.CrossCutting.Cryptography;
using System;

namespace AleffGroup.Application.AppServices
{
    public class LoginAppService : ILoginAppService
    {
        private readonly IUserService _userService;

        public LoginAppService(IUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        public void Login(string username, string password)
        {
            var user = _userService.GetUserByName(username);
            if (user == null) throw new ArgumentNullException(nameof(user)); 

            var passCrypt = MD5Hash.CalculateMD5Hash(password);
            if (password != passCrypt) throw new ArgumentNullException(nameof(user));
        }
    }
}
