using System;

namespace AleffGroup.Application.Extensions
{
    public class LoginException : Exception
    {
        public LoginException(string message) : base(message)
        {
        }
    }
}
