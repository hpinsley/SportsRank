using NUnit.Framework;

namespace ScoreParser.Tests {
    [TestFixture]
    public class FileParserTester : TestBase {
        private const string NFL2012 = @"C:\Users\pinsley\Google Drive\NFL Results\NFL-2012-Results.txt";

        [Test]
        public void CanGetStats() {
            ITeamManager teamManager = new TeamManager();
            ResultsParser parser = new ResultsParser(teamManager);
            Games games = parser.ParseGameResults(NFL2012);
            Assert.IsNotNull(games);
            Assert.AreEqual(256, games.Count);

            foreach (Game game in games.GetGames()) {
                LogMsg(game.ToString());
            }

            foreach (Team team in teamManager.GetTeams()) {
                LogMsg("Team Manager has {0}", team);
            }

            Assert.AreEqual(32, teamManager.TeamCount);
        }
    }
}