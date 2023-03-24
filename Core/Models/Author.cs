using System.Collections.Generic;

namespace Core.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Book> Books { get; set; } = new List<Book>();

        public override string ToString()
        {
            return Name;
        }
    }
}
