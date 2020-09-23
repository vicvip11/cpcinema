namespace Core.Model
{
    public class Movie
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Length { get; set; }
        public string Desc { get; set; }
        public MovieGenre Genre { get; set; }
        public string ImageString { get; set; }
        public byte[] ImageBytes { get; set; }
    }
}
