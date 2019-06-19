using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Okapia.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
            var customers = new List<Okapia.Models.Customer>
            {
                new Okapia.Models.Customer
                {
                    Name = "محمد",
                    Family = "نصیری",
                    NationalCardNumber = "00193010250",
                    PhoneNumber = "09126663344"
                },
                new Okapia.Models.Customer
                {
                    Name = "سعید",
                    Family = "روستایی",
                    NationalCardNumber = "0020604050",
                    PhoneNumber = "09126663694"
                },
                new Okapia.Models.Customer
                {
                    Name = "مهدی",
                    Family = "ثالث",
                    NationalCardNumber = "0016349576",
                    PhoneNumber = "09125544888"
                },
            };
            return View(customers);
        }

        // GET: Customers/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
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

        // GET: Customers/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Customers/Edit/5
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

        // GET: Customers/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Customers/Delete/5
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