using FootballTeamStats;
class  FootballTeamStatistics
{
    public delegate void AddTeamHandler(IScorable team);

    public static event AddTeamHandler TeamAdded;

    static void Main()
    {
        List<IScorable> teams = new List<IScorable>();
        Console.WriteLine("Welcome to the program for displaying statistics of football teams!\n");
        while (true)
        {
            
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Add football team\n");
            Console.WriteLine("2. Display statistics\n");
            Console.WriteLine("3. Save to memory/file\n");
            Console.WriteLine("Q. Quit the application\n");

            char choice = Console.ReadKey().KeyChar;
            Console.WriteLine();

            switch (choice)
            {
                case '1':
                    AddTeam(teams);
                    break;
                case '2':
                    DataOperations.DisplayStatistics(teams);
                    break;
                case '3':
                    FileOperations.SaveData(teams);
                    break;
                case 'Q':
                case 'q':
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
    static void AddTeam(List<IScorable> teams)
    {
        Console.WriteLine("Enter the name of the football team:");
        string teamName = Console.ReadLine();

        int[] goals = DataOperations.ReadGoals();

        FootballTeam newTeam = new FootballTeam(teamName, goals);
        teams.Add(newTeam);

        TeamAdded?.Invoke(newTeam);

        Console.WriteLine($"Team {teamName} added with match results: {string.Join(", ", goals)}");
        Console.WriteLine("Team added successfully!");
    }
}
