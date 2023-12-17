using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AleffGroup.WebMvc.ViewModels
{
    public class LogAccessViewModel
    {
        [Key]
        public int LogAcessoId { get; set; }

        [DisplayName("Nome do Usuário")]
        public string UserName { get; set; }

        [DisplayName("Data/Hora Acesso")]
        public DateTime DateTimeAccess { get; set; }

        [Required(ErrorMessage = "Endereço IP")]
        public string AdressIp { get; set; }

    }

    public class LogAccessPageViewModel
    {
        public IEnumerable<LogAccessViewModel> LogAccessViewModel { get; set; }
        public DotNet.Highcharts.Highcharts HighCharts { get; set; }
    }
}