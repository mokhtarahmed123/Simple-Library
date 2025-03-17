using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Library
{
    internal class Book
    {
        public int BookID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public bool IsBorrowed { get; set; }
        //public  Member MemberID { get; set; }
        //public int? MemberID { get; set; }
        //public Member? Member { get; set; }

        public  int? MemberID { get; set; }  // Nullable, in case book is not borrowed

        // Navigation Property
        public Member? Member { get; set; }
      public  static List<Book>  books = new List<Book>();

        //public string CreateBook(int BookID, string Title, string Author, string ISBN)
        //{
        //    Book book = books.Find((b) => b.BookID == BookID);
        //    if (book is not null) {
        //        return "the Book Found";
        //    }
        //    Book BOOK = new Book()
        //    {
        //        BookID = BookID,
        //        Title = Title,
        //        Author = Author,
        //        ISBN = ISBN
        //    };
        //    books.Add(BOOK);
        //    return "the Book Created ";
        //}
        //public string ReadBookInfo(int BookID)
        //{
        //    Book book = books.Find((b) => b.BookID == BookID);
        //    if (book is  null)
        //    {
        //        return "the Book Not Found";
        //    }
        //    return $"BookID  :{book.BookID} ,Title : {book.Title} , Author :{book.Author} , ISBN :{book.ISBN} ";

        //}
        //public string UpdateBookInfo(int BookIDOld ,int BookIDNew, string Title, string Author, string ISBN)
        //{
        //    Book book = books.Find((b) => b.BookID == BookIDOld);
        //    if (book is null)
        //    {
        //        return "the Book Not Found";
        //    }
        //    book.Title = Title;
        //    book.Author = Author;
        //    book.ISBN = ISBN;
        //     book.BookID = BookIDNew;
        //    return "The Information Is Updated";
        //}
        //public string DeleteBook(int BookID) {
        //    Book book = books.Find((b) => b.BookID == BookID);
        //    if (book is null)
        //    {
        //        return "the Book Not Found";
        //    }
        //    books.Remove(book);
        //    return "Book is removed";
        //}
    }
}
