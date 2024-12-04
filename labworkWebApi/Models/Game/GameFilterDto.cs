namespace labworkWebApi.Models.Game
{
    public class GameFilterDto
    {
        public string? Name { get; set; }
        public string? Developer { get; set; }
        public string? Publisher { get; set; }
        public int? GenreId { get; set; }
    }
}
