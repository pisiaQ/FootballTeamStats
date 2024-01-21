namespace FootballTeamStats
{
    class DataOperations
    {
        public static int[] ReadGoals()
        {
            int[] goals = new int[5];

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Enter the number of goals in match {i + 1} between 0 and 10 (or WALK for 0 goals):");
                string input = Console.ReadLine();

                if (input.ToLower() == "walk")
                {
                    goals[i] = 0;
                }
                else if (int.TryParse(input, out int goal) && goal >= 0 && goal <= 10)
                {
                    goals[i] = goal;
                    Console.WriteLine($"Goal added: {goal}");
                }
                else
                {
                    Console.WriteLine("Incorrect data phrase. Enter a number between 0 and 10 or 'WALK'.\n");
                    i--;
                }
            }

            return goals;
        }

        public static void DisplayStatistics(List<IScorable> teams)
        {
            if (teams.Count == 0)
            {
                Console.WriteLine("No data to display.\n");
                return;
            }

            Console.WriteLine("Teams ranking:\n");

            int location = 1;

            foreach (var team in teams.OrderByDescending(t => t.GetTotalGoals()))
            {
                Console.WriteLine($"Position {location}: Team: {team.Name}");
                Console.WriteLine($"Min. goals: {team.GetMinGoals()}");
                Console.WriteLine($"Max. goals: {team.GetMaxGoals()}");
                double averageGoals = team.GetAverageGoals();
                Console.WriteLine($"Average goals: {averageGoals}");

                char grade = team.GetAverageGrade();
                Console.WriteLine($"Average grade: {grade}\n");
                location++;
            }
        }
    }
}