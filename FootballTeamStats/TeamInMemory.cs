namespace FootballTeamStats
{
    public class TeamInMemory : TeamBase
    {
        private List<int> goals = new List<int>();

        public TeamInMemory(string teamName)
            : base(teamName)
        {
        }

        public override void AddGoal(int goals)
        {
            this.goals.Add(goals);
            base.OnGoalAdded();
            base.AddToTeamGoalSum(goals);
        }

        public override Statistics GetTeamStatistics()
        {
            return CountStatistics(goals.ToArray());
        }

        private Statistics CountStatistics(int[] goals)
        {
            var statistics = new Statistics();

            foreach (var goal in goals)
            {
                statistics.AddGoal(goal);
            }

            return statistics;
        }
    }
}
