using StudentLibraryManagement;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace StudentLibraryManagement
{
    internal class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public BookCategory Category { get; set; }
        public decimal DailyFee { get; set; }
        public bool IsAvailable { get; set; }

        public Book()
        {

        }
        
        public Book(int bookId, string title, string author, BookCategory category, decimal dailyFee, bool isAvailable)
        {
            BookId = bookId;
            Title = title;
            Author = author;
            Category = category;
            DailyFee = dailyFee;
            IsAvailable = true;
        }

        

        public override string ToString()
        {
            string available = "";
            if (IsAvailable)
                available = "Yes";
            else
                available = "No";

            return $"BookID: {BookId} " +
                 $"\nTitle: {Title}" +
                 $"\nAuthor: {Author}" +
                 $"\nCategory: {Category}" +
                 $"\nDaily Fee: {DailyFee: C}" +
                 $"Available: {available}";

        }

        public static decimal operator +(Book book1, Book book2)
        {
            return book1.DailyFee + book2.DailyFee;
        }

        public override bool Equals(object? obj)
        {
            
            if (obj is Book newBook)
            {
                return BookId == newBook.BookId;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return BookId.GetHashCode();
        }

        public static bool operator ==(Book book1, Book book2)
        {
            if (ReferenceEquals(book1, book2))
                return false;

            return book1.BookId == book2.BookId;
        }

        public static bool operator !=(Book book1, Book book2)
        {
            return book1.BookId != book2.BookId;
        }

        public static bool operator >(Book book1, Book book2)
        {
            if (book1 is null || book2 is null) return false;

            return book1.DailyFee > book2.DailyFee;
        }

        public static bool operator <(Book book1, Book book2)
        {
            if (book1 is null || book2 is null) return false;

            return book1.DailyFee < book2.DailyFee;
        }
    }
}
