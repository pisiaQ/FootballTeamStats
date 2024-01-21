namespace FootballTeamStats
{
    public class FootballTeam : SportsTeamBase
    {
        public FootballTeam(string name, int[] goals) : base(name, goals)
        {
        }

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