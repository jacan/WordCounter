using System;
using Xunit;

namespace WordCount.Tests
{
    public class WordTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Word_Must_Contain_A_Valid_String(string nullOrEmptyString)
        {
            Assert.Throws<ArgumentException>(() => new Word(nullOrEmptyString, 1));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Word_Occurrence_Cannot_BeBelow_1(int occurenceCount)
        {
            Assert.Throws<ArgumentException>(() => new Word("word", occurenceCount));
        }
    }
}
