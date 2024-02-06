namespace FootballTeamStats.Tests
{
    public class StatisticsTests
    {
        [Test]
        public void GetTeamStatistics_ReturnsCorrectStatistics()
        {
            // Arrange
            var team = new TeamInMemory("Test Team");
            team.AddGoal(2);
            team.AddGoal(4);
            team.AddGoal(6);

            // Act
            var statistics = team.GetTeamStatistics();

            // Assert
            Assert.AreEqual(3, statistics.Count);
            Assert.AreEqual(12, statistics.Sum);
            Assert.AreEqual(2, statistics.Min);
            Assert.AreEqual(6, statistics.Max);
            Assert.AreEqual(4, statistics.Average);
            Assert.AreEqual('D', statistics.AverageLetter);
        }

        [Test]
        public void AddGoal_CalculatesTotalGoalsAndAverageCorrectly()
        {
            // Arrange
            var team = new TeamInMemory("Test Team");

            // Act
            team.AddGoal(2);
            team.AddGoal(4);
            team.AddGoal(6);

            // Assert
            var statistics = team.GetTeamStatistics();
            Assert.AreEqual(12, statistics.Sum);
            Assert.AreEqual(4, statistics.Average);
        }
        [Test]
        public void GetTeamStatistics_TeamWithOneGoal_ReturnsCorrectStatistics()
        {
            // Arrange
            var team = new TeamInMemory("Single Goal Team");
            team.AddGoal(3); 

            // Act

            // Assert
            var statistics = team.GetTeamStatistics();
            Assert.AreEqual(3, statistics.Sum);
            Assert.AreEqual(1, statistics.Count);
            Assert.AreEqual(3, statistics.Average);
            Assert.AreEqual(3, statistics.Min);
            Assert.AreEqual(3, statistics.Max);
            Assert.AreEqual('D', statistics.AverageLetter); 
        }

    }
}
