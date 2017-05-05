using System;
using System.IO;
using System.Linq;

namespace WordCount
{
    class Program
    {
        private static string ExampleFile = "Example.txt";
        
        static void Main(string[] args)
        {
            var fileLines = File.ReadAllLines(ExampleFile);
            var line = fileLines.FirstOrDefault();

            if (string.IsNullOrWhiteSpace(line))
            {
                return;
            }

            Console.WriteLine($"The sentence \"{line}\" contains the follwing:");

            var wordCounter = new WordCounter(' ');
            var wordCount = wordCounter.GetUniqueWordCountInString(line);

            wordCount
                .ToList()
                .ForEach(x => Console.WriteLine($"{x.OccurenceCount}: {x.Value}"));
        }
    }
}
