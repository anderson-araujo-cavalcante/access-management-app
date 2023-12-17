using AleffGroup.Domain.Entities;

namespace AleffGroup.Domain.Interfaces.Services
{
    public interface IUserService : IServiceBase<User>
    {
        void ValidateUserPassword(string password);

        User GetUserByName(string username);
    }
}
