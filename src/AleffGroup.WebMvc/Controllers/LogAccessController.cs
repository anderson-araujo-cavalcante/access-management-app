using AleffGroup.Application.Interfaces;
using AleffGroup.Domain.Model;
using AleffGroup.WebMvc.ViewModels;
using AutoMapper;
using DotNet.Highcharts;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web.Mvc;

namespace AleffGroup.WebMvc.Controllers
{
    public class LogAccessController : Controller
    {
        private readonly ILogAccessAppService _logAccessApp;
        private readonly IMapper _mapper;

        public LogAccessController(ILogAccessAppService logAccessApp,
            IMapper mapper)
        {
            _logAccessApp = logAccessApp ?? throw new ArgumentNullException(nameof(logAccessApp));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        // GET: LogAccess
        public ActionResult Index()
        {
            var logs = _logAccessApp.GetAllByUserId(1);
            var logByTime = _logAccessApp.GetPeriodByUserId(1);

            var chart = GenerateChertData(logByTime);

            var view = new LogAccessPageViewModel()
            {
                LogAccessViewModel = _mapper.Map<IEnumerable<LogAccessViewModel>>(logs),
                HighCharts = chart
            };

            return View(view);
        }

        private Highcharts GenerateChertData(IEnumerable<LogTime> log)
        {
            var logGroup = log.GroupBy(x => x.UserId);
            var series = logGroup.Select(x => new Series
            {
                Name = x.Key.ToString(),
                Data = new Data(x.Select(d => d.Total).Cast<object>().ToArray()),
            }).Cast<Series>().ToArray();

            var categories = log.Select(x => x.Period.ToString("HH:mm")).Distinct().ToArray();

            Highcharts chart = new Highcharts("linechart");
            chart.InitChart(new Chart()
            {
                Type = DotNet.Highcharts.Enums.ChartTypes.Line,
                BackgroundColor = new BackColorOrGradient(System.Drawing.Color.AliceBlue),
                Style = "fontWeight: 'bold', fontSize: '17px'",
                BorderColor = System.Drawing.Color.LightBlue,
                BorderRadius = 0,
                BorderWidth = 2
            });
            chart.SetTitle(new Title()
            {
                Text = "Acessos por hora"
            });
            chart.SetSubtitle(new Subtitle()
            {
                Text = "Acessos realizados entre horários de 00:00 até as 23:59"
            });
            chart.SetXAxis(new XAxis()
            {
                Type = AxisTypes.Category,
                Title = new XAxisTitle() { Text = "Horas", Style = "fontWeight: 'bold', fontSize: '17px'" },
                Categories = categories
            });
            chart.SetYAxis(new YAxis()
            {
                Title = new YAxisTitle()
                {
                    Text = "Qtde. acessos",
                    Style = "fontWeight: 'bold', fontSize: '17px'"
                },
                ShowFirstLabel = true,
                ShowLastLabel = true,
                Min = 0
            });
            chart.SetLegend(new Legend
            {
                Enabled = true,
                BorderColor = System.Drawing.Color.CornflowerBlue,
                BorderRadius = 6,
                BackgroundColor = new BackColorOrGradient(ColorTranslator.FromHtml("#FFADD8E6"))
            });
            chart.SetSeries(series);
            return chart;
        }
    }
}