namespace FootballTeamStats
{
    public interface ITeam
    {
        string TeamName { get; }
        void AddGoal(int goals);
        Statistics GetTeamStatistics();
        void DisplayTeamStatistics();
        event TeamBase.GoalAddedDelegate GoalAdded;
    }
}
