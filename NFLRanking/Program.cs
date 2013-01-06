using System;
using ScoreParser;

namespace NFLRanking {
    class Program {
        
        private const string NFL2012 = @"C:\Users\pinsley\Google Drive\NFL Results\NFL-2012-Results.txt";

        static void Main() {
            ITeamManager teamManager = new TeamManager();
            IGameManager gameManager = new GameManager(teamManager);
            ResultsParser parser = new ResultsParser(gameManager);

            parser.ParseGameResults(NFL2012);
            Console.WriteLine();
            ListTeams(teamManager);
            Console.WriteLine();
            AnalyzeTeam(teamManager.GetTeam("NY Giants"));
            Console.WriteLine();
            AnalyzeTeam(teamManager.GetTeam("Washington"));
        }

        private static void ListTeams(ITeamManager teamManager) {
            foreach (Team team in teamManager.GetTeams()) {
                Console.WriteLine("{0} is graded a {1}", team, team.Grade);
            }
        }


        private static void AnalyzeTeam(Team team) {
            TeamAnalysis analysis = Grader.GetTeamGradeAnalysis(team);
            foreach (TeamGameAnalysis tga in analysis.GetGameAnalyses()) {
                Console.WriteLine("{0} {1} {2} {3} {4}\tCredit:{5} Total:{6}",
                       tga.Team.Name,
                       tga.RelationshipToOtherTeam,
                       tga.OtherTeam.Record,
                       tga.OtherTeam,
                       tga.Game.Score,
                       tga.GameGrade,
                       tga.CumulativeGrade);
            }
        }
    }
}
