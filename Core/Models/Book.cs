namespace Core.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }

        public override string ToString()
        {
            if (Author == null)
            {
                return Title;
            }
            return $"{Author} - {Title}";
        }
    }
}
