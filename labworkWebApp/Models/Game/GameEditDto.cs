namespace labworkWebApp.Models.Game
{
    public class GameEditDto
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Developer { get; set; }
        public string? Publisher { get; set; }
        public string Access { get; set; }
        public string? Category { get; set; }
        public int GenreId { get; set; }
    }
}
