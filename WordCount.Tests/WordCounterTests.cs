using System;
using System.Linq;
using Xunit;
using FluentAssertions;

namespace WordCount.Tests
{
    public class WordCounterTests
    {
        [Fact]
        public void Words_Are_Counted_Correctly()
        {
            string line = "two five two five five five five";
            var sut = new WordCounter(' ');

            var result = sut.GetUniqueWordCountInString(line);

            result.Should().HaveCount(2);
            result.First().OccurenceCount.Should().Be(2);
            result.Last().OccurenceCount.Should().Be(5);
        }
        
        [Theory]
        [InlineData("one two one one")]
        [InlineData("two two two one one")]
        [InlineData("one two one two one two")]
        public void All_Lines_Are_Counted_Correctly(string line)
        {
            var sut = new WordCounter(' ');

            var result = sut.GetUniqueWordCountInString(line);

            result.Last().OccurenceCount.Should().Be(3);
        }

        [Fact]
        public void Line_Is_Counted_As_One_With_Invalid_Delimiter()
        {
            string line = "two five two five five five five";
            var sut = new WordCounter(';');

            var result = sut.GetUniqueWordCountInString(line);

            result.Should().HaveCount(1);
        }

        [Fact]
        public void Argument_Exception_Is_Thrown_When_Empty_String_Is_Supplied()
        {
            string line = string.Empty;
            var sut = new WordCounter(';');

            Assert.Throws<ArgumentException>(() => sut.GetUniqueWordCountInString(line));
        }
    }
}
