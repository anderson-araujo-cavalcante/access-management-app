using AleffGroup.Domain.Entities;
using AleffGroup.Domain.Interfaces.Repositories;
using AleffGroup.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace AleffGroup.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository clienteRepository)
        {
            _userRepository = clienteRepository ?? throw new ArgumentNullException(nameof(clienteRepository));
        }

        public void Add(User entity)
        {
            _userRepository.Add(entity);
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User GetById(int id)
        {
            return _userRepository.GetById(id);
        }

        public void Remove(User entity)
        {
            _userRepository.Remove(entity);
        }

        public void Remove(int id)
        {
            _userRepository.Remove(id);
        }

        public void Update(User entity)
        {
            _userRepository.Update(entity);
        }

        public void Dispose()
        {
            _userRepository.Dispose();
        }

    }
}
