using System.Collections.Generic;

namespace ScoreParser {
    public interface ITeamManager {
        Team GetTeam(string teamName);
        int TeamCount { get; }
        IEnumerable<Team> GetTeams();
    }
}