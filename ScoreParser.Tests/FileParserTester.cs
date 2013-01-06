using NUnit.Framework;

namespace ScoreParser.Tests {
    [TestFixture]
    public class FileParserTester : TestBase {
        private const string NFL2012 = @"C:\Users\pinsley\Google Drive\NFL Results\NFL-2012-Results.txt";

        [Test]
        public void CanGetStats() {
            ITeamManager teamManager = new TeamManager();
            IGameManager gameManager = new GameManager(teamManager);

            ResultsParser parser = new ResultsParser(gameManager);
            parser.ParseGameResults(NFL2012);

            foreach (Team team in teamManager.GetTeams()) {
                LogMsg("Team Manager has {0}", team);
            }

            Assert.AreEqual(32, teamManager.TeamCount);
            Team giants = teamManager.GetTeam("NY Giants");
            Assert.AreEqual(21, giants.Grade);
        }
    }
}