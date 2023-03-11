using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagementApp.Domain
{
    public class Author: BaseEntity
    {
        public Author()
        {

        }

        public Author(string firstName, string lastName, string avatarUrl, Guid publisherId)
        {
            FirstName = firstName;
            LastName = lastName;
            AvatarUrl = avatarUrl;
            PublisherId = publisherId;
        }
        
        public string FirstName{get; set;}
        public string LastName{get; set;}
        public string AvatarUrl{get; set;}
        public Guid PublisherId{get; set;}
        public Publisher Publisher { get; set; }
        public ICollection<Book> Books{get; set;}
        
        [NotMapped]
        public int TotBooks
        {
            get
            {
                return (Books != null)
                    ? Books.Count
                    : _TotBooks;
            }
            set => _TotBooks = value;
        }
        private int _TotBooks;
    }
}