using FootballTeamStats;

class FBTS
{
    static void Main()
    {
        Console.WriteLine("Welcome to Team Statistics Program!");

        var teams = new List<ITeam>();

        while (true)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Add Team");
            Console.WriteLine("2. Enter Goals for Teams");
            Console.WriteLine("3. Display Statistics for Teams");
            Console.WriteLine("Q. Quit");

            Console.Write("Select an option: ");
            string choice = Console.ReadLine().ToUpper();

            switch (choice)
            {
                case "1":
                    AddTeam(teams);
                    break;
                case "2":
                    EnterGoalsForTeams(teams);
                    break;
                case "3":
                    DisplayStatisticsForAllTeams(teams);
                    break;
                case "Q":
                    Console.WriteLine("Exiting the program...");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    private static void AddTeam(List<ITeam> teams)
    {
        Console.Write("Enter name for the team: ");
        string teamName = Console.ReadLine();
        var team = new TeamInFile(teamName);
        team.GoalAdded += TeamGoalAdded;
        teams.Add(team);
        Console.WriteLine($"Team {teamName} added successfully!");
    }

    private static void TeamGoalAdded(object sender, EventArgs args)
    {
        Console.WriteLine("Goal added to the team!");
    }

    private static void EnterGoalsForTeams(List<ITeam> teams)
    {
        Console.WriteLine("Adding goals for teams...");

        foreach (var team in teams)
        {
            AddGoalsForMatches(team, 5);
            Console.WriteLine();
        }
    }

    private static void AddGoalsForMatches(ITeam team, int numberOfMatches)
    {
        for (int matchNumber = 1; matchNumber <= numberOfMatches; matchNumber++)
        {
            Console.Write($"Enter goals for match {matchNumber} for {team.TeamName}: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int goals) && goals >= 0 && goals <= 10)
            {
                team.AddGoal(goals);
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number of goals between 0 and 10.");
                matchNumber--;
            }
        }
    }

    private static void DisplayStatisticsForAllTeams(List<ITeam> teams)
    {
        Console.WriteLine("Statistics for all teams (sorted by total goals):\n");

        // Sortowanie zespołów według sumy goli (DESCENDING)
        var sortedTeams = teams.OrderByDescending(team => (team as TeamBase)?.TeamTotalGoals ?? 0).ToList();

        foreach (var team in sortedTeams)
        {
            team.DisplayTeamStatistics();
        }
    }
}
