using AleffGroup.Application.Interfaces;
using AleffGroup.WebMvc.ViewModels;
using Azure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AleffGroup.WebMvc.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginAppService _loginApp;

        public LoginController(ILoginAppService loginApp)
        {
            _loginApp = loginApp ?? throw new ArgumentNullException(nameof(loginApp));
        }
        public ActionResult Index()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel user)
        {
            if (ModelState.IsValid) 
            {
                try
                {
                    string ipAddress = Request.ServerVariables["X_FORWARDED_FOR"];
                    if (ipAddress == null)
                    {
                        ipAddress = Request.ServerVariables["REMOTE_ADDR"];
                    }

                    _loginApp.Login(user.Login, user.Password, ipAddress);

                    //Session["usuarioLogadoID"] = v.Id.ToString();
                    //Session["nomeUsuarioLogado"] = v.NomeUsuario.ToString();
                    return RedirectToAction("Index", "User");
                }
                catch (Exception ex)
                {
                    throw;// ex.Message;
                }                
            }
            return View(user);
        }
    }
}