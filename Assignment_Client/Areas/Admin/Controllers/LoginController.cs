using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assignment_Client.Areas.Admin.Models;

namespace Assignment_Client.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        AdminService adminService = new AdminService();
        // GET: Admin/Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            var result = adminService.Login(model);
            if (result == true)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Login", "Login");

            }
        }
    }
}