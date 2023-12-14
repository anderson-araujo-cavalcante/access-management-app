using System;

namespace AleffGroup.Domain.Entities
{
    public class LogAccess
    {
        public int LogAcessoId { get; set; }
        public int UsuarioId { get; set; }
        public DateTime DataHoraAcesso { get; set; }
        public string EnderecoIp { get; set; }

    }
}
