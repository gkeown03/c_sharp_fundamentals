using Xunit;
using System;

namespace GradeBook.Tests;

public class BookTests
{
    [Fact]
    public void BookCalculatesAnAverageGrade()
    {
        var book = new DiskBook("Test 1");
        book.AddGrade(10);
        book.AddGrade(77.2);
        book.AddGrade(99.8);
 
        var result = book.GetStatistics();

        Assert.Equal(10, result.Low);
        Assert.Equal(99.8, result.High);
        Assert.Equal(62.33, result.Average, 2);
        Assert.Equal('D', result.Letter);
    }
}