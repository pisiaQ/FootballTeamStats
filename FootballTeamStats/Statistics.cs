namespace FootballTeamStats
{
    public class Statistics
    {
        public float Min { get; private set; }
        public float Max { get; private set; }
        public float Sum { get; private set; }
        public int Count { get; private set; }

        public float Average
        {
            get
            {
                return Sum / Count;
            }
        }

        public char AverageLetter
        {
            get
            {
                switch (Average)
                {
                    case var average when average >= 10:
                        return 'A';
                    case var average when average >= 7:
                        return 'B';
                    case var average when average >= 5:
                        return 'C';
                    case var average when average >= 3:
                        return 'D';
                    default:
                        return 'E';
                }
            }
        }

        public Statistics()
        {
            Count = 0;
            Sum = 0;
            Max = float.MinValue;
            Min = float.MaxValue;
        }

        public void AddGoal(float goal)
        {
            Count++;
            Sum += goal;
            Min = Math.Min(goal, Min);
            Max = Math.Max(goal, Max);
        }
    }
}
