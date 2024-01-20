namespace FootballTeamStats
{
    class FileOperations
    {
        public static void SaveData(List<IScorable> teams)
        {
            if (teams.Count == 0)
            {
                Console.WriteLine("No data to save.\n");
                return;
            }

            Console.WriteLine("Choose the save type (M - Memory, F - File):");
            char saveChoice = Console.ReadKey().KeyChar;
            Console.WriteLine();

            switch (saveChoice)
            {
                case 'M':
                case 'm':
                    Console.WriteLine("Data saved to memory.");
                    break;
                case 'F':
                case 'f':
                    FileOperations.SaveToFile(teams);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Saving to memory.");
                    break;
            }
        }

        public static void SaveToFile(List<IScorable> teams)
        {
            Console.WriteLine("Enter the file name to save to:");
            string fileName = Console.ReadLine();

            try
            {
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    foreach (var team in teams)
                    {
                        writer.WriteLine($"{team.Name}: {string.Join(", ", team.Goals)}");
                    }
                }

                Console.WriteLine($"Data saved to file {fileName}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during file save: {ex.Message}");
            }
        }
    }
}
