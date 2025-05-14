namespace LibraryApi.Model
{
    public class Book
    {
        public int Id { get; set; }
        public string Isbn { get; set; }
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }

        public Book()
        {
            this.CreatedAt = DateTime.Now;
        }
    }
}
