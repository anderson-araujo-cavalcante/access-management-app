using AleffGroup.Domain.Entities;

namespace AleffGroup.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        User GetByUserName(string userName);
    }
}
