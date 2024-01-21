namespace FootballTeamStats.Tests
{
    public class MinMaxStatisticsTest
    {
        [Test]
        public void GetMinGoals_ReturnsMinimumGoals()
        {
            // Arrange
            int[] goals = { 7, 9, 8, 3, 1 };
            FootballTeam footballTeam = new FootballTeam("Test Team", goals);

            // Act
            int minGoals = footballTeam.GetMinGoals();

            // Assert
            Assert.AreEqual(1, minGoals);
        }

        [Test]
        public void GetMaxGoals_ReturnsMaximumGoals()
        {
            // Arrange
            int[] goals = { 2, 10, 1, 3, 9 };
            FootballTeam footballTeam = new FootballTeam("Test Team", goals);

            // Act
            int maxGoals = footballTeam.GetMaxGoals();

            // Assert
            Assert.AreEqual(10, maxGoals);
        }
    }
}