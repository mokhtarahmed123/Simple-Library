using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Library
{
    internal class Member :   INotification
    {
        public int MemberID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public static List<Member> Members { get; set; } = new List<Member>();
        //public ICollection<Book> Books { get; set; } = new List<Book>();

        public List<Book> BorrowedBooks { get; set; } = new List<Book>();
        //public object Books { get; internal set; }

        //public string CreateMember(int MemberID , string Name , string Email)
        //{
        //    Member M = Members.Find((id) => id.MemberID == MemberID);
        //    if(M is not null)
        //    {
        //        return "This Member Is Found ";
        //    }
        //    Member member = new Member()
        //    {
        //        MemberID = MemberID,
        //        Name = Name,
        //        Email = Email

        //    };
        //    //member.MemberID = MemberID;
        //    //member.Name = Name;
        //    //member.Email = Email;
        //    Members.Add(member);

        //    return "The Member Is Created";
        //}
        //public string ReadMember(int MemberID)
        //{
        //    Member member = Members.Find((m)=> m.MemberID == MemberID);
        //    if(member is  null)
        //    {
        //        return("this Member Not Found , Please Try Again"); 
        //    }
        //    return ($"The Name Of Member:    {member.Name} , The Email Of Member: {member.Email},  The ID Of Member :{member.MemberID} ");
        //}
        //public string UpdateMember( int MemberIDold , int MemberIDNew  , string Name , string email)
        //{
        //    Member member = Members.Find((m) => m.MemberID == MemberIDold);
        //    if (member is null)
        //    {
        //        Console.WriteLine("this Member Not Found , Please Try Again");
        //    }
        //    member.MemberID = MemberIDNew;
        //    member.Name = Name;
        //    member.Email = email;

        //    return "The Member Information Is updated";
        //}
        //public string DeleteMember(int MemberID)
        //{
        //    Member M = Members.Find((id) => id.MemberID == MemberID);
        //    if (M is null) {
        //        return("this Member Not Found , Please Try Again");
        //    }
        //    Members.Remove(M);
        //    return "The Member IS Removed";
        //}
        public string SendNotification(string message)
        {
            { return $"You {message} the Book"; }
        }

    }

}
