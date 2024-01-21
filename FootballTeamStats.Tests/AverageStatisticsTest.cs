namespace FootballTeamStats.Tests
{
    public class AverageStatisticsTest
    {
        [Test]
        public void GetAverageGoals_ReturnsAverageGoals()
        {
            // Arrange
            int[] goals = { 10, 5, 8, 0, 7 };
            FootballTeam footballTeam = new FootballTeam("Test Team", goals);

            // Act
            double averageGoals = footballTeam.GetAverageGoals();

            // Assert
            Assert.AreEqual(6.0, averageGoals);
        }

        [Test]
        public void GetTotalGoals_ReturnsTotalGoals()
        {
            // Arrange
            int[] goals = { 2, 4, 1, 3, 0 };
            FootballTeam footballTeam = new FootballTeam("Test Team", goals);

            // Act
            int totalGoals = footballTeam.GetTotalGoals();

            // Assert
            Assert.AreEqual(10, totalGoals);
        }

        [Test]
        public void GetAverageGrade_ReturnsCorrectGrade()
        {
            // Arrange
            int[] goals = { 1, 5, 5, 5, 5 };
            FootballTeam footballTeam = new FootballTeam("Test Team", goals);

            // Act
            char averageGrade = footballTeam.GetAverageGrade();

            // Assert
            Assert.AreEqual('B', averageGrade);
        }
    }
}
