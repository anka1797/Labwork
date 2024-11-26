using System.ComponentModel.DataAnnotations;

namespace labworkData
{
    public class GameGenre
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
