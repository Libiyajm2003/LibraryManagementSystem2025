using LibraryManagementSystem2025.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagementSystem2025.Service
{
    //ILibraryService interface is implemented in LibraryServiceImpl 
    public class LibraryServiceImpl : ILibraryService
    {
        private List<Book> books = new List<Book>(); 
        private Random random = new Random();

        // Adds a new book to the list
        public void AddBook(Book book)
        {
            books.Add(book);
        }

        // Edits a book based on ISBN
        public void EditBook(string isbn)
        {
            var book = books.FirstOrDefault(b => b.ISBN == isbn);
            if (book == null)
            {
                Console.WriteLine("Book not found.");
                return;
            }

            Console.Write("Enter new Title: ");
            book.Title = Console.ReadLine();

            Console.Write("Enter new Author: ");
            book.Author = Console.ReadLine();

            Console.Write("Enter new Published Date (dd/MM/yyyy): ");
            string dateInput = Console.ReadLine();
            if (!Utility.ValidationHelper.IsValidDate(dateInput, out DateTime date))
            {
                Console.WriteLine("Invalid date format!");
                return;
            }
            book.PublishedDate = date;

            Console.WriteLine("Book updated successfully!");
        }

        // Lists all books
        public void ListAllBooks()
        {
            if (books.Count == 0)
            {
                Console.WriteLine("No books available.");
                return;
            }

            books.ForEach(b => Console.WriteLine(b));
        }

        // Removes a book by ISBN
        public void RemoveBook(string isbn)
        {
            var book = books.FirstOrDefault(b => b.ISBN == isbn);
            if (book == null)
            {
                Console.WriteLine("Book not found.");
                return;
            }

            books.Remove(book);
            Console.WriteLine("Book removed successfully!");
        }

        // Searches books by author
        public List<Book> SearchByAuthor(string author)
        {
            return books.Where(b => b.Author.ToLower().Contains(author.ToLower())).ToList();
        }

        // Searches books by title
        public List<Book> SearchByTitle(string title)
        {
            return books.Where(b => b.Title.ToLower().Contains(title.ToLower())).ToList();
        }

        // Generates a unique ISBN
        public string GenerateUniqueISBN()
        {
            string isbn;
            do
            {
                isbn = random.Next(10000, 99999).ToString(); // 5-digit ISBN
            } while (books.Any(b => b.ISBN == isbn));
            return isbn;
        }
    }
}
