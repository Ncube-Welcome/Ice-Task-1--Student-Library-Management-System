using System;
using System.Collections.Generic;

namespace StudentLibraryManagement
{
    // This is the ENUM 
    public enum BookCategory { Technology, Science, Literature, History, Other }

    // STUDENT RECORD
    public record StudentRecord(string StudentNumber, string FullName, string Course);

    // TEMPORARY STUBS – REMOVE WHEN REAL CLASSES ARE READY 

    
    

    public class Library
    {
        public void RegisterStudent(StudentRecord student)
            => Console.WriteLine($"STUB: Registered student {student.FullName}");

        public void AddBook(Book book = new Book())
            => Console.WriteLine($"STUB: Added book '{book.Title}'");

        public void DisplayBooks()
            => Console.WriteLine("STUB: Displaying all books..."); // book list with overriden .ToString to be used

        public List<Book> SearchBook(string titleSubstring)
            => new List<Book>();

        public bool RemoveBook(int bookId)
        {
            Console.WriteLine($"STUB: Removing book with ID {bookId}");
            return true;
        }

        public decimal CalculateTotalBorrowingFee()
        {
            Console.WriteLine("STUB: Calculating total fee...");
            return 0m;
        }

        public void CompareBooks(int id1, int id2)
            => Console.WriteLine($"STUB: Comparing books {id1} and {id2}");
    }

    //  Menu and user input
    class Program
    {
        private static Library library = new Library();

        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\n===========================");
                Console.WriteLine("UNIVERSITY LIBRARY SYSTEM");
                Console.WriteLine("===========================");
                Console.WriteLine("1. Register Student");
                Console.WriteLine("2. Add Book");
                Console.WriteLine("3. Display Books");
                Console.WriteLine("4. Search Book");
                Console.WriteLine("5. Remove Book");
                Console.WriteLine("6. Calculate Total Borrowing Fee");
                Console.WriteLine("7. Compare Two Books");
                Console.WriteLine("0. Exit");
                Console.Write("Enter the number of your choice: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                try
                {
                    switch (choice)
                    {
                        case "1": RegisterStudent(); break;
                        case "2": AddBook(); break;
                        case "3": DisplayBooks(); break;
                        case "4": SearchBook(); break;
                        case "5": RemoveBook(); break;
                        case "6": CalculateTotalFee(); break;
                        case "7": CompareTwoBooks(); break;
                        case "0": exit = true; Console.WriteLine("Thank you for using the University Library System. Exiting..."); break;
                        default:
                            Console.WriteLine("Error, the option you have selected is invalid, please choose another option");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        // Interaction methods (input collection + calls to Library) 

        static void RegisterStudent()
        {
            Console.Write("Enter Student Number: ");
            string number = Console.ReadLine();
            Console.Write("Enter Full Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Course: ");
            string course = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(number) || string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(course))
                throw new ArgumentException("All student fields are required.");

            var student = new StudentRecord(number, name, course);
            library.RegisterStudent(student);
        }

        static void AddBook()
        {
            Console.Write("Enter Book ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
                throw new FormatException("Book ID must be an integer.");

            Console.Write("Enter Title: ");
            string title = Console.ReadLine();
            Console.Write("Enter Author: ");
            string author = Console.ReadLine();

            Console.WriteLine("Select Category:");
            foreach (var cat in Enum.GetValues(typeof(BookCategory)))
                Console.WriteLine($"  {(int)cat}. {cat}");
            Console.Write("Category number: ");
            if (!Enum.TryParse(Console.ReadLine(), out BookCategory category) || !Enum.IsDefined(typeof(BookCategory), category))
                throw new ArgumentException("Invalid category.");

            Console.Write("Enter Daily Fee (e.g., 150.00): ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal fee))
                throw new FormatException("Daily fee must be a decimal number.");

            var book = new Book(id, title, author, category, fee, true);
            library.AddBook(book);
        }

        static void DisplayBooks()
        {
            library.DisplayBooks();
        }

        static void SearchBook()
        {
            Console.Write("Enter title to search (or part of it): ");
            string search = Console.ReadLine();
            var results = library.SearchBook(search);
            Console.WriteLine($"Found {results.Count} book(s).");
        }

        static void RemoveBook()
        {
            Console.Write("Enter Book ID to remove: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
                throw new FormatException("Book ID must be an integer.");

            bool removed = library.RemoveBook(id);
            Console.WriteLine(removed ? "Book removed." : "Book not found.");
        }

        static void CalculateTotalFee()
        {
            decimal total = library.CalculateTotalBorrowingFee();
            Console.WriteLine($"Total Borrowing Fee: {total:C}");
        }

        static void CompareTwoBooks()
        {
            Console.Write("Enter Book ID of first book: ");
            if (!int.TryParse(Console.ReadLine(), out int id1))
                throw new FormatException("Invalid ID.");
            Console.Write("Enter Book ID of second book: ");
            if (!int.TryParse(Console.ReadLine(), out int id2))
                throw new FormatException("Invalid ID.");

            library.CompareBooks(id1, id2);
        }
    }
}