using System;
using Xunit;


namespace GradeBook.Tests
{
    public delegate string WriteLogDelegate(string logMessage);

    public class TypeTest
    {


        public void WriteLogDelegatePoint()
        {
            WriteLogDelegate logDelegate;
            logDelegate = new WriteLogDelegate(ReturnMessage);

            var result = logDelegate("Hello!");
            Assert.Equal("Hello!", result);
        }

        string ReturnMessage(string message)
        {
            return message;
        }
        //fact is attribute 
        //fact is attached to method
        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");
            
            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotSame(book1,book2);
        }
        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            var book1 = GetBook("Book 1");
            var book2 = book1;
            
            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));
        }

        [Fact]
        public void CanSetNameFromReference()
        {
            var book1 = GetBook("Book 1");
            SetName(book1, "New Name");
            
            Assert.Equal("New Name", book1.Name);
        }

        private void SetName(Book book, string name){
            book.Name = name;
        }

        DiskBook GetBook(string name)
        {
            return new DiskBook(name);
        }
    }
}
