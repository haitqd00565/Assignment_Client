    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assignment_Client.Models;

namespace Assignment_Client.Controllers
{
    public class HomeController : Controller
    {
        AdminService adminService = new AdminService();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Service()
        {
            ViewBag.listPlace = adminService.GetPlace();
            return View();
        }
        public ActionResult Detail(int id)
        {
            ViewBag.listImage = adminService.GetAllImage(id);
            //ViewBag.listComment = adminService.GetCommentList(id);
            return View();
        }
        public ActionResult ListComment(int id)
        {
            ViewBag.listComment = adminService.GetCommentList(id);
            return View();
        }
        [HttpGet]
        public ActionResult AddComment()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddComment(Comment comment)
        {
            var result = adminService.AddComment(comment);
            if (result == true)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Detail", "Home");
            }
        }
        
    }
}