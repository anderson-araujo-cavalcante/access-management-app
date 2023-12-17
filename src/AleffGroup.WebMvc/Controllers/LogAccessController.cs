using AleffGroup.Application.Interfaces;
using AleffGroup.Domain.Entities;
using AleffGroup.WebMvc.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            return View(_mapper.Map<IEnumerable<LogAccessViewModel>>(logs));
        }
    }
}