namespace labworkWebApi.Models.Game
{
    public class GameGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Developer { get; set; }
        public string? Publisher { get; set; }
        public string? Category { get; set; }
        public string FullCompany { get; set; }
        public int GenreId { get; set; }
        public string GenreName { get; set; }
        public string Access { get; set; }
    }
}
