namespace GradeBook
{
    public class Statistics
    {
        double low;
        double high;
        double average;
        char letter;
        double total;
        double count;

        public double Low { get => low;  }
        public double High { get => high; }
        public double Total { get => total; }
        public double Count { get => count; }


        public double Average
        {
            get => total / count;
        }

        public char Letter
        {
            get
            {
                switch(Average)
                {
                    case var d when d > 90.0:
                        return 'A';
                    case var d when d > 80.0:
                        return 'B';
                    case var d when d > 70.0:
                        return 'C';
                    case var d when d > 60.0:
                        return 'D';
                    default:
                        return 'F';
                }
            }
        }

        public Statistics()
        {
            high = double.MinValue;
            low = double.MaxValue;
            average = 0.0;
            total = 0.0;
            count = 0;
        }

        public void Add(double number)
        {
            total += number;
            high = Math.Max(High, number);
            low = Math.Min(Low, number);
            count++;
        }

    }
}