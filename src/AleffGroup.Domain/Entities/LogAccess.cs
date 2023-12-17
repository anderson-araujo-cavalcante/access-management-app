using System;

namespace AleffGroup.Domain.Entities
{
    public class LogAccess
    {
        public int LogAcessoId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime DateTimeAccess { get; set; }
        public string AdressIp { get; set; }

    }
}
