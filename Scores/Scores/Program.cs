using System;

namespace Scores
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter in your first name.");
            string date = DateTime.Today.ToShortDateString();
            string uName = Console.ReadLine();
            string msg = $"\nWelcome back {uName}. Today is {date}";
            Console.WriteLine(msg);

            string path = @"C:\Users\burro\Desktop\Big C# Projects\The-Tech-Academy-C-Sharp-Coding-Projects\Scores\Scores\studentsScores.txt";
            string[] lines = System.IO.File.ReadAllLines(path);
            
            double totalS = 0.0;

            Console.WriteLine("\nStudent Score: \n");
            foreach (string line in lines)
            {
                Console.WriteLine("\n " + line);
                double score = Convert.ToDouble(line);
                totalS += score;
            }

            double avgScore = totalS / lines.Length;
            Console.WriteLine("\nTotal of " + lines.Length + " students scores. \tAverage score: " + avgScore);

            Console.WriteLine("\n\nPress any key to exit.");
            Console.ReadKey();
        }
    }
}
