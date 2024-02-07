namespace FootballTeamStats
{
    public class TeamInFile : TeamBase
    {
        private string FileName;

        public TeamInFile(string teamName)
            : base(teamName)
        {
            FileName = $"{teamName.ToLower()}_goals.txt"; 
        }

        public override void AddGoal(int goals)
        {
            using (var writer = File.AppendText(FileName))
            {
                writer.WriteLine(goals);
            }
            base.OnGoalAdded();

            Console.WriteLine($"Goals added to {TeamName}. Data saved to file: {FileName}");
        }

        public override Statistics GetTeamStatistics()
        {
            var goalsFromFile = ReadGoalsFromFile();
            return CountStatistics(goalsFromFile);
        }

        private float[] ReadGoalsFromFile()
        {
            var goals = new List<float>();

            if (File.Exists(FileName))
            {
                using (var reader = File.OpenText(FileName))
                {
                    string line;

                    while ((line = reader.ReadLine()) != null)
                    {
                        if (float.TryParse(line, out float goal))
                        {
                            goals.Add(goal);
                        }
                    }
                }
            }

            return goals.ToArray();
        }

        private Statistics CountStatistics(float[] goals)
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
