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

        public ActionResult Index() {
            IEnumerable<Team> teams = _teamManager.GetTeams();
            ViewBag.Title = "2012 NFL Regular Season Grades";
            return View(teams);
        }

        public ActionResult Details(string teamName) {
            Team team = _teamManager.GetTeam(teamName);
            TeamAnalysis analysis = Grader.GetTeamGradeAnalysis(team);
            IEnumerable<TeamGameAnalysis> teamGameAnalyses = analysis.GetGameAnalyses();
            ViewBag.Team = team;
            return View(teamGameAnalyses);
        }
    }
}
