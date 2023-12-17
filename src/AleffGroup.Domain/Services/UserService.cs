using AleffGroup.Domain.Entities;
using AleffGroup.Domain.Interfaces.Repositories;
using AleffGroup.Domain.Interfaces.Services;
using AleffGroup.Infra.CrossCutting.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AleffGroup.Domain.Services
{
    public class UserService : ServiceBase<User>, IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository) : base(userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public void Add(User entity)
        {
            ValidateUserPassword(entity.Senha);
            entity.Senha = MD5Hash.CalculateMD5Hash(entity.Senha);
            _userRepository.Add(entity);
        }

        //public IEnumerable<User> GetAll()
        //{
        //    return _userRepository.GetAll();
        //}

        //public User GetById(int id)
        //{
        //    return _userRepository.GetById(id);
        //}

        //public void Remove(User entity)
        //{
        //    _userRepository.Remove(entity);
        //}

        //public void Remove(int id)
        //{
        //    _userRepository.Remove(id);
        //}

        //public void Update(User entity)
        //{
        //    _userRepository.Update(entity);
        //}

        public void ValidateUserPassword(string password)
        {
            List<string> msg = new List<string>();

            var stringValidate = password.Replace(" ", "");
            if (string.IsNullOrEmpty(stringValidate)) msg.Add("Informar senha.");

            if (stringValidate.Length < password.Length) msg.Add("A senha não deve possuir espaços em branco.");

            //ninimo 10 caracteres
            if (stringValidate.Length < 10) msg.Add("A senha deve conter 10 ou mais caracteres");

            //existe caracter especial
            var specialCharacters = @"!@#$%^&*()-+";
            if (!stringValidate.Any(x => specialCharacters.Contains(x))) msg.Add("A senha deve conter ao menos 1 dos caracteres especiais a seguir: !@#$%^&*()-+rd");

            // existe numero
            if (!stringValidate.Any(x => char.IsDigit(x))) msg.Add("A senha deve conter ao menos 1 dígito numérico");

            //bool result = stringValidate.Any(x => !char.IsLetter(x));
            if (!stringValidate.Any(x => char.IsLetter(x))) msg.Add("A senha deve conter ao menos 1 letra minúscula");

            // existe maiuscula
            if (!stringValidate.Any(x => char.IsLower(x))) msg.Add("A senha deve conter ao menos 1 letra maiúscula");

            //caracter duplicado
            var removeDuplicate = new string(stringValidate.ToCharArray().Distinct().ToArray());
            if (removeDuplicate.Length < stringValidate.Length) msg.Add("A senha não deve possuir caracteres repetidos");
        }

        public User GetUserByName(string username)
        {
            return _userRepository.GetByUserName(username);
        }

        public void Dispose()
        {
            _userRepository.Dispose();
        }
    }
}
