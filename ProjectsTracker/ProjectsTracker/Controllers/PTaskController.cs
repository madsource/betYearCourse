using ProjectsTracker.Services.Contracts;
using ProjectsTracker.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectsTracker.Controllers
{
    [Authorize]
    public class PTaskController : Controller
    {

        private IUsersService userService;
        private IPTaskService ptaskService;

        public PTaskController(IUsersService userService, IPTaskService ptaskService)
        {
            this.userService = userService;
            this.ptaskService = ptaskService;
        }
             

        // GET: PTask
        public ActionResult Index()
        {

            PTaskViewModel ptaskVM = new PTaskViewModel();
            return View(ptaskVM);
        }

        // GET: PTask/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PTask/Create
        public ActionResult Create()
        {
            PTaskViewModel ptaskVM = new PTaskViewModel();
            return View(ptaskVM);
        }

        // POST: PTask/Create
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

        // GET: PTask/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PTask/Edit/5
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

        // GET: PTask/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PTask/Delete/5
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
