namespace FootballTeamStats
{
   public abstract class SportsTeamBase : IScorable
    {
        private string name;
        private int[] goals;

        public event EventHandler GoalsChanged;

        public SportsTeamBase(string name, int[] goals)
        {
            this.name = name;
            this.goals = goals;
        }

        public string Name => name;

        public int[] Goals => goals;

        public virtual int GetMinGoals() => goals.Min();
        public virtual int GetMaxGoals() => goals.Max();
        public virtual double GetAverageGoals() => goals.Average();
        public virtual int GetTotalGoals() => goals.Sum();

        public char GetAverageGrade()
        {
            double averageGoals = GetAverageGoals();

            if (averageGoals >= 4.5)
            {
                return 'A';
            }
            else if (averageGoals >= 3.5)
            {
                return 'B';
            }
            else if (averageGoals >= 2.5)
            {
                return 'C';
            }
            else if (averageGoals >= 1.5)
            {
                return 'D';
            }
            else
            {
                return 'E';
            }
        }
    }

}