using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Okapia.Areas.Job.Controllers
{
    [Area("Job")]
    public class IntroduceController : Controller
    {
        // GET: Introduce
        public ActionResult Index()
        {
            return View();
        }

        // GET: Introduce/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Introduce/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Introduce/Create
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

        // GET: Introduce/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Introduce/Edit/5
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

        // GET: Introduce/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Introduce/Delete/5
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