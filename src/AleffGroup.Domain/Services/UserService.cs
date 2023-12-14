using AleffGroup.Domain.Interfaces.Repositories;

namespace AleffGroup.Domain.Services
{
    public class UserService : ServiceBase<Entities.User, int>, Interfaces.Services.IUserService
    {
        //private readonly IUserRepository _userRepository;

        public UserService(IUserRepository clienteRepository)
            : base(clienteRepository)
        {
            //_userRepository = clienteRepository;
        }
    }
}
