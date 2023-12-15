using AleffGroup.Application.Interfaces;
using AleffGroup.Domain.Entities;
using AleffGroup.WebMvc.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AleffGroup.WebMvc.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserAppService _userApp;
        private readonly IMapper _mapper;

        public UserController(IUserAppService userApp,
            IMapper mapper)
        {
            _userApp = userApp ?? throw new ArgumentNullException(nameof(userApp));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public ActionResult Index()
        {
            var users = _userApp.GetAll();
            return View(_mapper.Map<IEnumerable<UserViewModel>>(users));
        }

        public ActionResult Details(int id)
        {
            var user = _userApp.GetById(id);
            return View(_mapper.Map<UserViewModel>(user));
        }

        public ActionResult Create()
        {
            return View(new UserViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserViewModel user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userDomain = _mapper.Map<User>(user);
                    _userApp.Add(userDomain);

                    return RedirectToAction("Index");
                }

                return View(user);
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var user = _userApp.GetById(id);
            var userViewModel = _mapper.Map<UserViewModel>(user);

            return View(userViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserViewModel user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userDomain = _mapper.Map<User>(user);
                    _userApp.Update(userDomain);

                    return RedirectToAction("Index");
                }

                return View(user);
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            var user = _userApp.GetById(id);
            var userViewModel = _mapper.Map<UserViewModel>(user);

            return View(userViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var user = _userApp.GetById(id);
                _userApp.Remove(user);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
