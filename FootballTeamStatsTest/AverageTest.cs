namespace FootballTeamStats.Tests
{
    public class AverageTests
    { 
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
        public void AddGoal_CalculatesAverageCorrectlyWhenNoGoalsAdded()
        {
            // Arrange
            var team = new TeamInMemory("Test Team");

            // Act
            team.AddGoal(0);
            // Assert
            var statistics = team.GetTeamStatistics();
            Assert.AreEqual(0, statistics.Sum);
            Assert.AreEqual(0, statistics.Average);
        }

        [Test]
        public void AddGoal_CalculatesAverageCorrectlyWhenSingleGoalAdded()
        {
            // Arrange
            var team = new TeamInMemory("Test Team");

            // Act
            team.AddGoal(3);

            // Assert
            var statistics = team.GetTeamStatistics();
            Assert.AreEqual(3, statistics.Sum);
            Assert.AreEqual(3, statistics.Average);
        }
    }
}
