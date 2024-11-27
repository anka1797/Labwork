using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace labworkData
{
    public class Game
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Developer { get; set; }
        public string? Publisher { get; set; }

        [ForeignKey(nameof(Genre))]
        public int GenreId { get; set; }
        public GameGenre? Genre { get; set; }
        public string Access { get; set; }
        public string? Category { get; set; }
    }
}
