namespace FootballTeamStats.Tests
{
    public class AddGoal
    {
        [Test]
        public void AddGoal_AddsGoalToTeam()
        {
            // Arrange
            var team = new TeamInMemory("Test Team");

            // Act
            team.AddGoal(3);

            // Assert
            var statistics = team.GetTeamStatistics();
            Assert.AreEqual(3, statistics.Sum);
        }
        public void AddGoal_OutsideRange_DoesNotAddGoalToTeam()
        {
            // Arrange
            var team = new TeamInMemory("Test Team");

            // Act
            team.AddGoal(15); // Dodanie goli poza zakresem 0-10

            // Assert
            var statistics = team.GetTeamStatistics();
            Assert.AreEqual(0, statistics.Sum);
        }

        [Test]
        public void AddGoal_WithZeroGoals_AddsZeroGoalToTeam()
        {
            // Arrange
            var team = new TeamInMemory("Test Team");

            // Act
            team.AddGoal(0);

            // Assert
            var statistics = team.GetTeamStatistics();
            Assert.AreEqual(0, statistics.Sum);
        }

        [Test]
        public void AddGoal_MultipleGoals_CalculatesTotalGoalsCorrectly()
        {
            // Arrange
            var team = new TeamInMemory("Test Team");

            // Act
            team.AddGoal(3);
            team.AddGoal(5);
            team.AddGoal(2);

            // Assert
            var statistics = team.GetTeamStatistics();
            Assert.AreEqual(10, statistics.Sum);
        }
    }
}