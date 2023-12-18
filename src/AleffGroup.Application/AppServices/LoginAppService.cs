using AleffGroup.Application.Interfaces;
using AleffGroup.Domain.Entities;
using AleffGroup.Domain.Extensions;
using AleffGroup.Domain.Interfaces.Services;
using AleffGroup.Infra.CrossCutting.Cryptography;
using System;

namespace AleffGroup.Application.AppServices
{
    public class LoginAppService : ILoginAppService
    {
        private readonly IUserService _userService;
        private readonly ILogAccessService _logAccessService;

        public LoginAppService(IUserService userService,
                                               ILogAccessService logAccessService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _logAccessService = logAccessService ?? throw new ArgumentNullException(nameof(logAccessService));
        }

        public void Login(string username, string password, string ip)
        {
            var user = _userService.GetUserByName(username) ?? throw new PasswordException();
            
            var passCrypt = MD5Hash.CalculateMD5Hash(password);
            if (password != passCrypt) throw new PasswordException();

            var log = new LogAccess()
            {
                UserId = user.UserId,
                DateTimeAccess = DateTime.UtcNow,
                AdressIp = ip
            };

            _logAccessService.Add(log);
        }
    }
}
