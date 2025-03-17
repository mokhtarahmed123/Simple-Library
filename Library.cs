using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Library
{
     class Library
    {
        //public int count = 0;
        public List<Book> BooksWithLibrary { get; set; } = Book.books;
        public List<Member> MembersWithLibrary { get; set; } = Member.Members;
        public List<PremiumMember> PremiumMembers { get; set; } = new List<PremiumMember>();

        public void AddBook(Book book)
        { BooksWithLibrary.Add(book); }
        public void AddMember(Member member)
        { MembersWithLibrary.Add(member); } 
        public void AddPremiumMembers(PremiumMember member)
        { PremiumMembers.Add(member); }



        //public virtual string BorrowBook(int memberId, int bookId)
        //{


        //    Book book = BooksWithLibrary.Find(b => b.BookID == bookId);

        //    Member member = MembersWithLibrary.Find(M => M.MemberID == memberId);
        //    if (member == null)
        //    {
        //        return "  invalid member";
        //    }
        //    if (book == null)
        //    {
        //        return "invalid Book";
        //    }
        //    if (book.IsBorrowed == true)
        //    {
        //        return $"This book {bookId} is already borrowed. Try borrowing another one.";
        //    }

        //    member.BorrowedBooks.Add(book);
        //    book.IsBorrowed = true;
        //    BooksWithLibrary.Remove(book);
        //    return member is PremiumMember ?
        //        $"You borrowed '{book.Title}'. (Premium Benefit: 20% discount on late fees)" :
        //        $"You borrowed '{book.Title}'."; ;
        //}
        //public string ReturnBook(int memberId, int bookId)
        //{
        //    Book book = new Book();
        //    book.BookID = bookId;
        //    Member member = new Member();
        //    member.BorrowedBooks.Remove(book);

        //    book.IsBorrowed = false;
        //    BooksWithLibrary.Add(book);

        //    return $" this book {bookId} is returned ";
        //}
        public virtual string BorrowBook(int memberId, int bookId)
        {
            Member member = MembersWithLibrary.Find(m => m.MemberID == memberId);
            Book book = BooksWithLibrary.Find(b => b.BookID == bookId);

            if (member == null)
            {
                return "Invalid member.";
            }

            if (book == null)
            {
                return "Invalid book.";
            }

            if (book.IsBorrowed)
            {
                return $"This book {bookId} is already borrowed. Try another one.";
            }

            // Add book to member's borrowed list
            member.BorrowedBooks.Add(book);
            book.IsBorrowed = true;

            return member is PremiumMember
                ? $"You borrowed '{book.Title}'. (Premium Benefit: 20% discount on late fees)"
                : $"You borrowed '{book.Title}'.";
        }

        public string ReturnBook(int memberId, int bookId)
        {
            Member member = MembersWithLibrary.Find(m => m.MemberID == memberId);
            if (member == null)
            {
                return "Invalid member.";
            }

            Book book = member.BorrowedBooks.Find(b => b.BookID == bookId);
            if (book == null)
            {
                return "This book was not borrowed by this member.";
            }

            
            member.BorrowedBooks.Remove(book);
            book.IsBorrowed = false;
            BooksWithLibrary.Add(book);

            return $"Book '{book.Title}' returned successfully.";
        }

    }
}
