using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Okapia.Application.Contracts;
using Okapia.Areas.Administrator.Models;
using Okapia.Domain.Contracts;

namespace Okapia.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class NotificationController : Controller
    {
        public NotificationController()
        {
        }

        // GET: Notification
        public ActionResult Index()
        {
            var notifications = new List<Notification>
            {
                new Notification
                {
                    Title = "استخدام در مجموعه",
                    Description = "مجموعه اًکاپیا از کارشناس نرم افزار استخدام می کند.",
                    FromDate = DateTime.Now,
                    ToDate = DateTime.Now.AddDays(2),
                    Link = "http://www.okapia.ir/Pages/Somepage"
                },
                new Notification
                {
                    Title = "تخفیف شگفت انگیز",
                    Description = "۳۰٪ تخفیف به مناسبت عید فطر",
                    FromDate = DateTime.Now,
                    ToDate = DateTime.Now.AddDays(2),
                    Link = "http://www.okapia.ir/Pages/Somepage"
                },
            };
            return View(notifications);
        }

        // GET: Notification/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Notification/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Notification/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Notification/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Notification/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Notification/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Notification/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}