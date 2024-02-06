namespace FootballTeamStats
{
    public abstract class TeamBase : ITeam
    {
        public delegate void GoalAddedDelegate(object sender, EventArgs args);

        public string TeamName { get; private set; }
        public float TeamTotalGoals { get; private set; } = 0;

        public event GoalAddedDelegate GoalAdded;

        public TeamBase(string teamName)
        {
            TeamName = teamName;
        }

        public abstract void AddGoal(int goals);
        public void AddGoal(int[] goals)
        {
            foreach (var goal in goals)
            {
                AddGoal(goal);
            }
        }

        public abstract Statistics GetTeamStatistics();

        public virtual void DisplayTeamStatistics()
        {
            var statistics = GetTeamStatistics();
            Console.WriteLine($"Statistics for {TeamName}:");
            Console.WriteLine($"Total Goals: {TeamTotalGoals}");
            Console.WriteLine($"Average Goals: {statistics.Average}");
            Console.WriteLine($"Min Goals: {statistics.Min}");
            Console.WriteLine($"Max Goals: {statistics.Max}");

            DisplayAverageLetter(statistics.Average);
        }

        protected void DisplayAverageLetter(float average)
        {
            char averageLetter;

            if (average >= 10)
            {
                averageLetter = 'A';
            }
            else if (average >= 7)
            {
                averageLetter = 'B';
            }
            else if (average >= 5)
            {
                averageLetter = 'C';
            }
            else if (average >= 3)
            {
                averageLetter = 'D';
            }
            else
            {
                averageLetter = 'E';
            }

            Console.WriteLine($"Average Letter for {TeamName}: {averageLetter}");
            Console.WriteLine();
        }

        protected void OnGoalAdded()
        {
            GoalAdded?.Invoke(this, EventArgs.Empty);
        }

        protected void AddToTeamGoalSum(int goals)
        {
            TeamTotalGoals += goals;
        }
    }
}
