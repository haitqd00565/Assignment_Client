using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Assignment_Client.Areas.Admin.Models;

namespace Assignment_Client.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        AdminService adminService = new AdminService();
        // GET: Admin/Home
        public ActionResult Index()
        {
            ViewBag.listPlaces = adminService.GetAllPlace();
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Place place)
        {
            var result = adminService.AddPlace(place);
            if (result == true)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Create", "Home");
            }
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Place place = adminService.Find(id);
            if (place == null)
                return HttpNotFound();
            return View(place);
        }
        [HttpPost]
        public ActionResult Edit(Place place)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    adminService.EditPlace(place);
                    return RedirectToAction("Index", "Home");
                }
                return RedirectToAction("Edit", "Home");
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Place place = adminService.Find(id);
            if (place == null)
                return HttpNotFound();
            return View(place);

        }
        [HttpPost]
        public ActionResult Delete(int id, Place p)
        {
            try
            {
                Place place = new Place();
                if (ModelState.IsValid)
                {
                    if (id == null)
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    place = adminService.Find(id);
                    if (place == null)
                        return HttpNotFound();
                    adminService.DeletePlace(place.Id);
                    return RedirectToAction("Index", "Home");
                }
                    return View(place);
            }
            catch
            {
                return View();
            }
        }
    }
}