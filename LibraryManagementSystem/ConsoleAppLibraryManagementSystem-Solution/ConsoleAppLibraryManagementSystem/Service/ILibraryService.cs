using LibraryManagementSystem2025.Model;
using System.Collections.Generic;

namespace LibraryManagementSystem2025.Service
{
    //create interface with unimplemented methods
    public interface ILibraryService
    {
        //add book
        void AddBook(Book book);
        //edit book
        void EditBook(string isbn);
        //generate unique id
        string GenerateUniqueISBN();
        //list all books
        void ListAllBooks();
        //remove book
        void RemoveBook(string isbn);
        //search book by author name
        List<Book> SearchByAuthor(string author);
        //search book by title name
        List<Book> SearchByTitle(string title);
    }
}
