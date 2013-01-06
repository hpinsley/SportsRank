using System.Collections.Generic;

namespace ScoreParser {
    public class TeamAnalysis {
        private List<TeamGameAnalysis> _teamGameAnalyses = new List<TeamGameAnalysis>();

        public void AddTeamGameAnalysis(TeamGameAnalysis teamGameAnalysis) {
            _teamGameAnalyses.Add(teamGameAnalysis);
        }

        public IEnumerable<TeamGameAnalysis> GetGameAnalyses() {
            return _teamGameAnalyses;
        }
    }
}