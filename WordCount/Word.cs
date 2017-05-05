using System;

namespace WordCount
{
    public class Word
    {
        public string Value { get; }
        public int OccurenceCount { get; }  

        public Word(string word, int occurrenceCount)
        {
            if (string.IsNullOrWhiteSpace(word))
            {
                throw new ArgumentException("An instance of Word must be initialized with a string containing characters", nameof(word));    
            }

            if (occurrenceCount <= 0)
            {
                throw new ArgumentException("A word must occur once, for word to exist", nameof(occurrenceCount));
            }

            Value = word;
            OccurenceCount = occurrenceCount;
        }
    }
}
