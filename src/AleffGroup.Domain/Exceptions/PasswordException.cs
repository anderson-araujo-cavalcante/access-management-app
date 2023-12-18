using System;

namespace AleffGroup.Domain.Extensions
{
    public class PasswordException : Exception
    {
        public PasswordException(string message = "Login ou Senha incorreto.") : base(message)
        {
        }
    }
}
