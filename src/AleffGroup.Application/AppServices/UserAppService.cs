using AleffGroup.Application.Interfaces;
using AleffGroup.Domain.Entities;
using AleffGroup.Domain.Interfaces.Services;

namespace AleffGroup.Application.AppServices
{
    public class UserAppService : AppServiceBase<User>, IUserAppService
    {
        public UserAppService(IUserService clienteService) : base(clienteService)
        {
        }
    }
}
