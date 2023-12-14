using AleffGroup.Domain.Entities;
using AleffGroup.Domain.Interfaces.Services;

namespace AleffGroup.Application.AppServices
{
    public class UserAppService : AppServiceBase<User, int>, Interfaces.IUserAppService
    {
        //private readonly IUserService _userService;

        public UserAppService(IUserService clienteService)
            : base(clienteService)
        {
           // _userService = clienteService;
        }
    }
}
