using AleffGroup.Domain.Entities;
using AleffGroup.Domain.Extensions;
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

        public void Update(User entity)
        {
            ValidateUserPassword(entity.Senha);
            entity.Senha = MD5Hash.CalculateMD5Hash(entity.Senha);
            _userRepository.Update(entity);
        }

        public void ValidateUserPassword(string password)
        {
            List<string> msg = new List<string>();

            var stringValidate = password.Replace(" ", "");
            if (string.IsNullOrEmpty(stringValidate)) msg.Add("Informar senha.");

            if (stringValidate.Length < password.Length) msg.Add("A senha não deve possuir espaços em branco.");

            if (stringValidate.Length < 10) msg.Add("A senha deve conter 10 ou mais caracteres.");

            var specialCharacters = @"!@#$%^&*()-+";
            if (!stringValidate.Any(x => specialCharacters.Contains(x))) msg.Add("A senha deve conter ao menos 1 dos caracteres especiais a seguir: !@#$%^&*()-+rd .");

            if (!stringValidate.Any(x => char.IsDigit(x))) msg.Add("A senha deve conter ao menos 1 dígito numérico.");

            if (!stringValidate.Any(x => char.IsLetter(x))) msg.Add("A senha deve conter ao menos 1 letra minúscula.");

            if (!stringValidate.Any(x => char.IsLower(x))) msg.Add("A senha deve conter ao menos 1 letra maiúscula.");

            var removeDuplicate = new string(stringValidate.ToCharArray().Distinct().ToArray());
            if (removeDuplicate.Length < stringValidate.Length) msg.Add("A senha não deve conter caracteres repetidos.");

            if (msg.Count() > 0) throw new PasswordException(string.Join(Environment.NewLine, msg));
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
