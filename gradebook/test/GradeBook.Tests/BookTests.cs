using System;
using Xunit;


namespace GradeBook.Tests
{
    public class BookTests
    {
        //fact is attribute 
        //fact is attached to method
        [Fact]
        public void BookCalculatesAnAverageGrade()
        {
            //arrage
            var book = new InMemoeryBook("");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);

            //act
            var result = book.GetStatistics();
           
            //assert
            Assert.Equal(85.6, result.Average, 1);
            Assert.Equal(90.5, result.High);
            Assert.Equal(77.3, result.Low);
        }
    }
}
