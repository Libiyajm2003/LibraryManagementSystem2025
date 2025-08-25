using System;

    namespace LibraryManagementSystem2025.Model
    {
    /// <summary>
    /// Represents a Book entity in the Library Management System.
    /// ISBN is auto-generated 5-digit unique number.
    /// </summary>
    public class Book
        {
        //Fields or properties
            public string BookID { get; set; }
            public string Title { get; set; }
            public string Author { get; set; }
            public DateTime PublishedDate { get; set; }
            public string ISBN { get; set; }
        //parameterized constructor
            public Book(string bookID, string title, string author, DateTime publishedDate, string isbn)
            {
                BookID = bookID;
                Title = title;
                Author = author;
                PublishedDate = publishedDate;
                ISBN = isbn;
            }
        //ToString 
            public override string ToString()
            {
                return $"BookID: {BookID}, Title: {Title}, Author: {Author}, PublishedDate: {PublishedDate:dd/MM/yyyy}, ISBN: {ISBN}";
            }
        }
    }