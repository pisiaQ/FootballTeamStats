using FootballTeamStats;

class FBTS
{
    static void Main()
    {
        Console.WriteLine("Welcome to Team Statistics Program!");
        Console.WriteLine("===================================");

        var teams = new List<ITeam>();

        Console.Write("Enter the number of teams: ");
        if (int.TryParse(Console.ReadLine(), out int numberOfTeams) && numberOfTeams > 0)
        {
            for (int i = 0; i < numberOfTeams; i++)
            {
                Console.Write($"Enter name for team {i + 1}: ");
                string teamName = Console.ReadLine();
                var team = new TeamInFile(teamName);
                team.GoalAdded += TeamGoalAdded;
                teams.Add(team);
            }

            foreach (var team in teams)
            {
                AddGoalsForMatches(team, 5);
                Console.WriteLine();
            }

            foreach (var team in teams)
            {
                DisplayTeamStatistics(team);
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid number of teams.");
        }

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }

    private static void TeamGoalAdded(object sender, EventArgs args)
    {
        Console.WriteLine("Goal added to the team!");
    }

    private static void AddGoalsForMatches(ITeam team, int numberOfMatches)
    {
        Console.WriteLine($"Adding goals for {team.TeamName}...");

        for (int matchNumber = 1; matchNumber <= numberOfMatches; matchNumber++)
        {
            Console.Write($"Enter goals for match {matchNumber} (type 'walk' for 0 goals): ");
            string input = Console.ReadLine();

            if (input.ToLower() == "walk")
            {
                team.AddGoal(0);
            }
            else if (int.TryParse(input, out int goals) && goals >= 0 && goals <= 10)
            {
                team.AddGoal(goals);
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number of goals between 0 and 10 or type 'walk' for 0 goals.");
                matchNumber--;
            }
        }
    }

    private static void DisplayTeamStatistics(ITeam team)
    {
        Console.WriteLine($"Statistics for {team.TeamName}:");

        var statistics = team.GetTeamStatistics();

        Console.WriteLine($"Total Goals: {statistics.Sum}");
        Console.WriteLine($"Average Goals: {statistics.Average}");
        Console.WriteLine($"Min Goals: {statistics.Min}");
        Console.WriteLine($"Max Goals: {statistics.Max}");
        Console.WriteLine($"Average Letter: {statistics.AverageLetter}");

        Console.WriteLine();
    }
}
