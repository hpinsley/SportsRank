using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ScoreParser;

namespace TeamGrade.Web.Controllers
{
    public class TeamController : Controller
    {
        private readonly ITeamManager _teamManager;

        public TeamController(ITeamManager teamManager) {
            _teamManager = teamManager;
        }

        //
        // GET: /Team/

        public ActionResult Index() {
            IEnumerable<Team> teams = _teamManager.GetTeams();
            ViewBag.Title = "2012 NFL Regular Season Grades";
            return View(teams);
        }

        //
        // GET: /Team/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Team/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Team/Create

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

        //
        // GET: /Team/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Team/Edit/5

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

        //
        // GET: /Team/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Team/Delete/5

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
