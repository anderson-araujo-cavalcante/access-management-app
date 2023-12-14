using AleffGroup.WebMvc.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AleffGroup.WebMvc.Controllers
{
    public class UserController : Controller
    {
        public UserViewModel UserViewModelMoc = new UserViewModel() {UserId = 1, Name="TST NAME", Login="LOGIN", Senha="Snh", IsAdmin=false};
        public ActionResult Index()
        {
            //return View(Enumerable.Empty<UserViewModel>());
            return View(new List<UserViewModel>() { UserViewModelMoc });
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View(UserViewModelMoc);
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
       
        public ActionResult Edit(int id)
        {
            return View(UserViewModelMoc);
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            return View(UserViewModelMoc);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
