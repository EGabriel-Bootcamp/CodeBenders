using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementApp.Domain
{
    public class Publisher: BaseEntity
    {
        public Publisher()
        {
            
        }
        public Publisher(string name, string logoUrl)
        {
            Name = name;
            LogoUrl = logoUrl;
        }
        
        public string Name{get; set;}
        public string LogoUrl{get; set;}
        public ICollection<Book> Books { get; set; }
        public ICollection<Author> Authors { get; set; }

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
        
        [NotMapped]
        public int TotAuthors
        {
            get
            {
                return (Books != null)
                    ? Books.Count
                    : _TotBooks;
            }
            set => _TotBooks = value;
        }
        private int _TotAuthors;
    }
}