using System.Linq;
using System.Collections.Generic;

namespace ScoreParser {
    public class TeamManager : ITeamManager {

        private List<Team> _teams = new List<Team>();
        public Team GetTeam(string teamName) {
            Team matchingTeam = _teams.FirstOrDefault(t => t.Name == teamName);
            if (matchingTeam == null) {
                matchingTeam = new Team(teamName);
                _teams.Add(matchingTeam);
            }
            return matchingTeam;
        }

        public int TeamCount {
            get { return _teams.Count; }
        }

        public IEnumerable<Team> GetTeams() {
            return _teams.OrderBy(t => t.Grade);
        }
    }
}