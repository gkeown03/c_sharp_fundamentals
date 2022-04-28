namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            IBook book = new DiskBook("My Grades");
            book.GradeAdded += OnGradeAdded;
            book.GradeAdded += OnGradeAdded;

            EnterGrades(book);

            var result = book.GetStatistics();
            Console.WriteLine($"Name {book.Name} Total {result.Total} High {result.High} " +
                              $"Low {result.Low} Avg {result.Average} Letter {result.Letter}");
        }

        private static void EnterGrades(IBook book)
        {
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "q")
                {
                    break;
                }
                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
                finally
                {
                    Console.WriteLine("*****");
                }
            }
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A grade was added");
        }
    }
}