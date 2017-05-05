using System;
using System.Linq;

namespace WordCount
{
    public class WordCounter
    {
        private readonly char _delimiter;

        public WordCounter(char delimiter)
        {
            _delimiter = delimiter;
        }

        public IOrderedEnumerable<Word> GetUniqueWordCountInString(string line)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                throw new ArgumentException("A Unique wordcount failed, cause the line is null or empty", nameof(line));
            }

            return line
                .Split(_delimiter)
                .GroupBy(x => x)
                .Select(x => new Word(x.Key, x.Count()))
                .OrderBy(x => x.OccurenceCount);
        }
    }
}
