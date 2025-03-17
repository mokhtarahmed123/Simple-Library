using Simple_Library.Model;
using System.Security.Cryptography;

namespace Simple_Library
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new MemberContext())
            {

                context.Database.EnsureCreated();
                int choise;
                do
                {
                    Console.WriteLine("Welcome To My Application");
                    Console.WriteLine("1- Menu Of Members");
                    Console.WriteLine("2- Menu Of Books");
                    Console.WriteLine("3- Exit");
                    choise = int.Parse(Console.ReadLine());
                    switch (choise)
                    {
                        case 1:
                            MemberMenu(context);
                            break;
                        case 2:
                            BookMenu(context); break;
                        case 3:
                            Console.WriteLine("Thank YOU");
                            break;
                        default:
                            Console.WriteLine("invalid input");
                            break;



                    }
                } while (!(choise == 3));



            }
        }
        private static void MemberMenu(MemberContext context)
        {
            try
            {
                Console.WriteLine("1- Create Member");
                Console.WriteLine("2- Read informantion Member");
                Console.WriteLine("3- Update Member");
                Console.WriteLine("4- Remove Member");
                Console.WriteLine("5- Create  PremiumMember Member");
                int memberChoice = int.Parse(Console.ReadLine());
                switch (memberChoice)
                {
                    case 1:
                        CreateMember(context);
                        break;
                    case 2:
                        ReadMember(context);
                        break;
                    case 3:
                        UpdateMember(context);
                        break;
                    case 4:
                        DeleteMember(context);
                        break;
                    case 5:
                        CreatePremiumMember(context);
                        break;
                    default:
                        Console.WriteLine("Invalid");
                        break;

                }

            }
            catch (Exception e) { Console.WriteLine(e.ToString()); }

        }
 
        private static void CreateMember(MemberContext context)
        {

            Console.WriteLine("ENTER NAME OF MEMBER");
            string name = Console.ReadLine();

            Console.WriteLine("ENTER EMAIL OF MEMBER");
            string email = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(email))
            {
                Console.WriteLine("Email cannot be empty. Please provide a valid email.");
                return;
            }

            var member = new Member { Name = name, Email = email };

            try
            {
                context.MembersTable.Add(member);
                context.SaveChanges();
                Console.WriteLine("Member Created Successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private static void ReadMember(MemberContext context)
        {

            Member member1 = new Member();
            Console.WriteLine(" ENTER ID OF MEMEBER");
            int MemberID1 = int.Parse(Console.ReadLine());
            var member = context.MembersTable.Find(MemberID1);
            if (member == null) { Console.WriteLine(" Member Not Found"); }
            else
            {
                Console.WriteLine($"Name: {member.Name}, Email: {member.Email}, ID: {member.MemberID}");

            }


        }
        private static void UpdateMember(MemberContext context)
        {
            Console.WriteLine("ENTER OLD ID OF MEMBER");
            int oldId = int.Parse(Console.ReadLine());

            Member member = context.MembersTable.Find(oldId);
            if (member == null)
            {
                Console.WriteLine("Member not found.");
                return;
            }

            Console.WriteLine("ENTER NEW NAME OF MEMBER");
            string newName = Console.ReadLine();
            Console.WriteLine("ENTER NEW EMAIL OF MEMBER");
            string newEmail = Console.ReadLine();

            member.Name = newName;
            member.Email = newEmail;

            context.SaveChanges();
            Console.WriteLine("Member updated successfully.");
        }

        //private static void UpdateMember(MemberContext context)
        //{
        //    Console.WriteLine("ENTER OLD ID OF MEMBER");
        //    int oldId = int.Parse(Console.ReadLine());
        //      Console.WriteLine("ENTER NAME OF MEMBER");
        //    string name = Console.ReadLine();
        //    Console.WriteLine("ENTER EMAIL OF MEMBER");
        //    string email = Console.ReadLine();

        //    var member = context.MembersTable.Find( oldId);
        //    if (member != null)
        //    {
        //        //member.MemberID = newId;
        //        member.Name = name;
        //        member.Email = email;
        //        Console.WriteLine("Member updated successfully.");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Member not found.");
        //    }
        //}
        //private static void DeleteMember(MemberContext context)
        //{
        //    Console.WriteLine("ENTER ID OF MEMBER");
        //    int memberId = int.Parse(Console.ReadLine());
        //    var member = context.MembersTable.Find(memberId);
        //    if (member != null)
        //    {
        //        Member. Members.Remove(member);
        //        Console.WriteLine("Member deleted successfully.");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Member not found.");
        //    }
        //}
        private static void DeleteMember(MemberContext context)
        {
            Console.WriteLine("ENTER ID OF MEMBER");
            int memberId = int.Parse(Console.ReadLine());
            var member = context.MembersTable.Find(memberId);
            if (member != null)
            {
                context.MembersTable.Remove(member);
                context.SaveChanges();
                Console.WriteLine("Member deleted successfully.");
            }
            else
            {
                Console.WriteLine("Member not found.");
            }
        }


        private static void CreatePremiumMember(MemberContext context)
        {
            Console.WriteLine("ENTER NAME OF MEMBER");
            string name = Console.ReadLine();

            Console.WriteLine("ENTER EMAIL OF MEMBER");
            string email = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(email))
            {
                Console.WriteLine("Email cannot be empty. Please provide a valid email.");
                return;
            }

            var premiumMember = new PremiumMember { Name = name, Email = email }; // No MemberID set!

            try
            {
                context.MembersTable.Add(premiumMember);
                context.SaveChanges();
                Console.WriteLine("Premium Member created successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.InnerException?.Message ?? ex.Message}");
            }
        }



        private static void BookMenu(MemberContext context)
        {
            try
            {
                Console.WriteLine("1- Create Book");
                Console.WriteLine("2- Read Book Information");
                Console.WriteLine("3- Update Book");
                Console.WriteLine("4- Remove Book");
                Console.WriteLine("5- Borrow Book");
                Console.WriteLine("6- Return Book");
                int bookChoice = int.Parse(Console.ReadLine());

                switch (bookChoice)
                {
                    case 1:
                        CreateBook(context);

                        break;
                    case 2:
                        ReadBook(context);
                        break;
                    case 3:
                        UpdateBook(context);
                        break;
                    case 4:
                        DeleteBook(context);
                        break;
                    case 5:
                        Console.WriteLine(" enter Member id");
                        int id = int.Parse(Console.ReadLine());       
                        Console.WriteLine(" enter Book id");
                        int BookId = int.Parse(Console.ReadLine());
                        Console.WriteLine(BorrowBook(id, BookId));
                        break;
                    case 6:
                        Console.WriteLine(" enter Member id");
                        int returnmemberid = int.Parse(Console.ReadLine());
                        Console.WriteLine(" enter Book id");
                        int returnBookId = int.Parse(Console.ReadLine());

                       ReturnBook(returnmemberid, returnBookId);  
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        private static void CreateBook(MemberContext context)
        {
            Console.WriteLine("ENTER TITLE OF BOOK");
            string title = Console.ReadLine();
            Console.WriteLine("ENTER AUTHOR OF BOOK");
            string author = Console.ReadLine();
            Console.WriteLine("ENTER ISBN OF BOOK");
            string isbn = Console.ReadLine();
           

            var book = new Book { Title = title, Author = author, ISBN = isbn ,  };
            context.BooksTable.Add(book);
            context.SaveChanges();
            Console.WriteLine("Book created successfully.");
        }
        private static void ReadBook(MemberContext context)
        {
            Console.WriteLine("ENTER ID OF BOOK");
            int bookId = int.Parse(Console.ReadLine());
            var book = context.BooksTable.Find(bookId);
            if (book != null)
            {
                Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, ISBN: {book.ISBN}");
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }

        private static void UpdateBook(MemberContext context)
        {
            Console.WriteLine("ENTER OLD ID OF BOOK");
            int oldId = int.Parse(Console.ReadLine());
            Console.WriteLine("ENTER NEW ID OF BOOK");
            int newId = int.Parse(Console.ReadLine());
            Console.WriteLine("ENTER TITLE OF BOOK");
            string title = Console.ReadLine();
            Console.WriteLine("ENTER AUTHOR OF BOOK");
            string author = Console.ReadLine();
            Console.WriteLine("ENTER ISBN OF BOOK");
            string isbn = Console.ReadLine();

            var book = context.BooksTable.Find(oldId);
            if (book != null)
            {
                book.BookID = newId;
                book.Title = title;
                book.Author = author;
                book.ISBN = isbn;
                context.SaveChanges();
                Console.WriteLine("Book updated successfully.");
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }

        private static void DeleteBook(MemberContext context)
        {
            Console.WriteLine("ENTER ID OF BOOK");
            int bookId = int.Parse(Console.ReadLine());
            var book = context.BooksTable.Find(bookId);
            if (book != null)
            {
                context.BooksTable.Remove(book);
                context.SaveChanges();
                Console.WriteLine("Book deleted successfully.");
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }


       
        public static string BorrowBook(int memberId, int bookId)
        {
            using (var context = new MemberContext())
            {
                var book = context.BooksTable.Find(bookId);
                var member = context.MembersTable.Find(memberId);

                if (book == null) return "Book not found.";
                if (member == null) return "Member not found.";

                book.MemberID = memberId;  
                book.IsBorrowed = true;
                context.SaveChanges();

                return $"Book {book.Title} has been borrowed by {member.Name}.";
            }
        }



        private static void ReturnBook(int memberId, int bookId)
        {
            using (var context = new MemberContext())
            {


                var book = context.BooksTable.Find(bookId);
                var member = context.MembersTable.Find(memberId);

                if (member == null || book == null)
                {
                    Console.WriteLine("Invalid member or book.");
                    return;
                }

                member.BorrowedBooks.Remove(book);
                book.IsBorrowed = false;
                book.MemberID = null;
                context.SaveChanges();

                Console.WriteLine($"Book '{book.Title}' returned successfully.");
            }
        }




    }
}
