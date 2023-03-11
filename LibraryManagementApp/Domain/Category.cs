using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementApp.Domain
{
    public class Category: BaseEntity
    {
        public Category()
        {
            
        }
        public Category(string name, string description)
        {
            Name = name;
            Description = description;
        }
        
        public string Name{get; set;}
        public string Description{get; set;}
        public ICollection<Book> Books{get; set;}
    }
}