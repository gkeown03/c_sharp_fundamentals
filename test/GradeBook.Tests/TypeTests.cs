using Xunit;
using System;

namespace GradeBook.Tests;

public delegate string WriteLogDelegate(string logMessage);

public class TypeTests
{
    int count = 0;
    [Fact]
    public void WriteLogDelegateCanPointToMethod()
    {
        WriteLogDelegate log = ReturnMessage;
        // log = new WriteLogDelegate(ReturnMessage);
        log += ReturnMessage;
        log += ReturnMessageLower;
        var result = log("Hello!");
        Assert.Equal("hello!", result);
        Assert.Equal(count, 3);
    }

    string ReturnMessage(string message)
    {
        count++;
        return message;
    }

    string ReturnMessageLower(string message)
    {
        count++;
        return message.ToLower();
    }

    [Fact]
    public void StringsBehaveLikeValueTypes()
    {
        string name = "Scott";
        string upper = MakeUpperCase(name);
        Assert.Equal(name, "Scott");
        Assert.Equal(upper, "SCOTT");
    }

    private string MakeUpperCase(string param)
    {
        return param.ToUpper();
    }

    [Fact]
    public void ValueTypesAlsoPassByValue()
    {
        var x = 3;
        SetInt(ref x);
        Assert.Equal(x, 42);
    }

    private void SetInt(ref int x)
    {
        x = 42;
    }

    [Fact]
    public void CSharpCanPassByValue()
    {
        var book1 = new Book("Book 1");
        GetBookSetName(ref book1, "New Name");
        Assert.Equal(book1.Name, "New Name");
    }

    private void GetBookSetName(ref Book book1, string name)
    {
        book1 = new Book(name);
    }

    [Fact]
    public void CSharpIsPassByValue()
    {
        var book1 = new Book("Book 1");
        GetBookSetName(book1, "New Name");
        Assert.Equal(book1.Name, "Book 1");
    }

    private void GetBookSetName(Book book1, string name)
    {
        book1 = new Book(name);
    }

    [Fact]
    public void CanSetNameFromReference()
    {
        var book1 = GetBook("Book 1");
        SetName(book1, "New Name");

        Assert.Equal("New Name", book1.Name);
    }

    private void SetName(Book book1, string name)
    {
        book1.Name = name;
    }

    [Fact]
    public void GetBookReturnsDifferentObject()
    {
        var book1 = GetBook("Book 1");
        var book2 = GetBook("Book 2");

        Assert.Equal("Book 1", book1.Name);
        Assert.Equal("Book 2", book2.Name);
        Assert.NotSame(book1, book2);
    }

    [Fact]
    public void TwoVarsCanReferenceSameObject()
    {
        var book1 = GetBook("Book 1");
        var book2 = book1;

        Assert.Same(book1, book2);
        Assert.True(Object.ReferenceEquals(book1, book2));
    }

    Book GetBook(string name)
    {
        return new Book(name);
    }
}