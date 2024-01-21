namespace FootballTeamStats
{
    public interface IScorable
    {
        string Name { get; }
        int[] Goals { get; }
        int GetMinGoals();
        int GetMaxGoals();
        double GetAverageGoals();
        int GetTotalGoals();
        char GetAverageGrade();

        event EventHandler GoalsChanged;
    }
}