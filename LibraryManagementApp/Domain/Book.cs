namespace LibraryManagementApp.Domain
{
    public class Book: BaseEntity
    {
        public Book()
        {

        }

        public Book(string title, string copyrightNotice, Guid authorId)
        {
            Title = title;
            CopyrightNotice = copyrightNotice;
            AuthorId = authorId;
        }
        
        public string Title{get; set;}
        public string CopyrightNotice{get; set;}
        public int ISBN{get; set;}
        public Guid AuthorId{get; set;}
        public Author Author { get; set; }
        public int PageLength{get; set;}
        public Language Language{get; set;}
        public DateOnly ReleaseYear{get; set;}
    }
}