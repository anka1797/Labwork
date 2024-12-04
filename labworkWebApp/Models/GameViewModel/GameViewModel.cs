using labworkWebApp.Models.Game;
using labworkWebApp.Models.GameGenre;

namespace labworkWebApp.Models.GameViewModel
{
    public class GameViewModel
    {
        public List<GameDto> Games { get; set; }
        public List<GenreDto> Genres { get; set; }
    }
}
