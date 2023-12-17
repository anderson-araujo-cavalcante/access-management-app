using System;

namespace AleffGroup.Domain.Model
{
    public class LogTime
    {
        public int UserId { get; set; }
        public DateTime Period { get; set; }
        public int Total { get; set; }
    }
}
