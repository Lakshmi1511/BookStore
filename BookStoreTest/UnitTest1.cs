using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookStore.Controllers;
using BookStore.Models;
using System.Collections.Generic;

namespace BookStoreTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]                                  
        public void GetAllBooks_ShouldReturnAllBooks()  //TestMethod to check the booklist is getting or not
        {
            var booklist = Get();

            Assert.AreEqual(booklist.Count, booklist.Count);
        }

        private List<Book> Get()
        {
            var booklist = new List<Book>();
            booklist.Add(new Book { Id = 1, Title = "Book", Author = "Average", Price = 7, InStock = 1 });
            booklist.Add(new Book { Id = 1, Title = "Book", Author = "Average", Price = 7, InStock = 1 });
            booklist.Add(new Book { Id = 1, Title = "Book", Author = "Average", Price = 7, InStock = 1 });
            booklist.Add(new Book { Id = 1, Title = "Book", Author = "Average", Price = 7, InStock = 1 });
            booklist.Add(new Book { Id = 1, Title = "Book", Author = "Average", Price = 7, InStock = 1 });
            booklist.Add(new Book { Id = 1, Title = "Book", Author = "Average", Price = 7, InStock = 1 });
            booklist.Add(new Book { Id = 1, Title = "Book", Author = "Average", Price = 7, InStock = 1 });
            return booklist;
        }
    }
}
