using StudentLibraryManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentLibraryManagement
{
    internal class Library
    {
        public StudentRecord? Student { get; set; }

        public List<Book> Books { get; set; } = new List<Book>();

        public void RegisterStudent(StudentRecord student)
        {
            Student = student;
        }

        public void AddBook(Book book)
        {
            if (Books.Any(b => b.BookId == book.BookId))
                throw new ArgumentException($"A book with ID {book.BookId} already exists.");

            Books.Add(book);
        }

        //Removes a book using its Book ID
        public bool RemoveBook(int bookId)
        {
            Book? book = Books.FirstOrDefault(b => b.BookId == bookId);

            if (book == null) 
            {
                throw new ArgumentException("Book not found.");
            }

            Books.Remove(book);
            return true;
        }

        //Searches for a book using its Book ID
        public Book? SearchBook(int bookId)
        {
            return Books.FirstOrDefault(b => b.BookId == bookId);
        }

        public void DisplayBooks()
        {
            if (Books.Count == 0)
            {
                Console.WriteLine("No books available.");
                return;
            }

            foreach (Book book in Books)
            {
                Console.WriteLine(book);
            }
        }

        public decimal CalculateTotalBorrowingFee()
        {
            // Adds the daily fee of all borrowed books
            return Books
                .Where(book => !book.IsAvailable)
                .Sum(book => book.DailyFee);
        }
    }
}