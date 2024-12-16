namespace ExampleApiSetup.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public int Length { get; set; }

        public string Genre { get; set; }

        public Movie(string title, string description, string author, int length, string genre)
        {
            Title = title;
            Description = description;
            Author = author;
            Length = length;
            Genre = genre;            
        }
    }
}
