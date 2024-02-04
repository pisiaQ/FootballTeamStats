namespace FootballTeamStats
{
    public class TeamInFile : TeamBase
    {
        private const string FileName = "goals.txt";

        public TeamInFile(string teamName)
            : base(teamName)
        {
        }

        public override void AddGoal(int goals)
        {
            try
            {
                File.AppendAllText(FileName, $"{TeamName}: {goals}\n");
                base.OnGoalAdded();
                base.AddToTeamGoalSum(goals);

                Console.WriteLine($"Goals added to {TeamName}. Data saved to file: {FileName}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while writing to the file: {ex.Message}");
            }
        }

        public void SaveToFile()
        {
            try
            {
                File.WriteAllText(FileName, $"{TeamName}: Data saved to file\n");
                Console.WriteLine($"Data saved to file for {TeamName}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while saving to file: {ex.Message}");
            }
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
                try
                {
                    using (var reader = File.OpenText(FileName))
                    {
                        string line;

                        while ((line = reader.ReadLine()) != null)
                        {
                            if (float.TryParse(line.Split(':')[1].Trim(), out float goal))
                            {
                                goals.Add(goal);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred while reading from the file: {ex.Message}");
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
