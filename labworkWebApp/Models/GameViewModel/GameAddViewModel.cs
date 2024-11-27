using labworkWebApp.Models.Game;
using labworkWebApp.Models.GameGenre;

namespace labworkWebApp.Models.GameViewModel
{
    public class GameAddViewModel
    {
        public GameAddDto Game { get; set; }
        public List<GenreDto> Genres { get; set; }
    }
}
