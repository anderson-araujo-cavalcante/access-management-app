using AleffGroup.Application.Interfaces;
using AleffGroup.Domain.Extensions;
using AleffGroup.WebMvc.ViewModels;
using System;
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
        public ActionResult Login(LoginViewModel login)
        {
            if (login == null)
            {
                ModelState.AddModelError("MsgValidate", "Informe Login e Senha.");
                return View("Index");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    string ipAddress = Request.ServerVariables["X_FORWARDED_FOR"];
                    if (ipAddress == null)
                    {
                        ipAddress = Request.ServerVariables["REMOTE_ADDR"];
                    }

                    _loginApp.Login(login.Login, login.Password, ipAddress);

                    //Session["usuarioLogadoID"] = v.Id.ToString();
                    //Session["nomeUsuarioLogado"] = v.NomeUsuario.ToString();
                    return RedirectToAction("Index", "User");
                }
                catch (PasswordException ex)
                {
                    ModelState.AddModelError("MsgValidate", ex.Message);
                    return View(login);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Exceptions", ex.Message);
                    return View(login);
                }
            }
            return View(login);
        }
    }
}