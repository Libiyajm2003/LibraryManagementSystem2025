using System;
using LibraryManagementSystem2025.Model;
using LibraryManagementSystem2025.Service;
using LibraryManagementSystem2025.Utility;

namespace LibraryManagementSystem2025
{
    class LibraryApp2025
    {
        static void Main()
        {
            //create an instance 
            ILibraryService library = new LibraryServiceImpl();
            bool exit = false;
            //Menu
            while (!exit)
            {
                Console.WriteLine("\n---- Library Management System 2025 ----");
                Console.WriteLine("1. List All Books");
                Console.WriteLine("2. Add Book");
                Console.WriteLine("3. Edit Book");
                Console.WriteLine("4. Remove Book");
                Console.WriteLine("5. Search By Author");
                Console.WriteLine("6. Search By Title");
                Console.WriteLine("7. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        library.ListAllBooks();
                        break;

                    case "2":
                        Console.Write("Enter BookID: ");
                        string bookID = Console.ReadLine();

                        Console.Write("Enter Title: ");
                        string title = Console.ReadLine();

                        Console.Write("Enter Author: ");
                        string author = Console.ReadLine();

                        Console.Write("Enter Published Date (dd/MM/yyyy): ");
                        string dateInput = Console.ReadLine();
                        if (!ValidationHelper.IsValidDate(dateInput, out DateTime date))
                        {
                            Console.WriteLine("Invalid date format!");
                            break;
                        }

                        // Auto-generate ISBN
                        string isbn = ((LibraryServiceImpl)library).GenerateUniqueISBN();

                        // Create Book
                        var book = new Book(bookID, title, author, date, isbn);
                        library.AddBook(book);
                        Console.WriteLine($"Book added successfully! Auto-generated ISBN: {isbn}");
                        break;

                    case "3":
                        Console.Write("Enter ISBN to edit: ");
                        library.EditBook(Console.ReadLine());
                        break;

                    case "4":
                        Console.Write("Enter ISBN to remove: ");
                        library.RemoveBook(Console.ReadLine());
                        break;

                    case "5":
                        Console.Write("Enter Author name to search: ");
                        var authorResults = library.SearchByAuthor(Console.ReadLine());
                        if (authorResults.Count == 0)
                            Console.WriteLine("No books found.");
                        else
                            authorResults.ForEach(b => Console.WriteLine(b));
                        break;

                    case "6":
                        Console.Write("Enter Title to search: ");
                        var titleResults = library.SearchByTitle(Console.ReadLine());
                        if (titleResults.Count == 0)
                            Console.WriteLine("No books found.");
                        else
                            titleResults.ForEach(b => Console.WriteLine(b));
                        break;

                    case "7":
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid option! Try again.");
                        break;
                }
            }
        }
    }
}

