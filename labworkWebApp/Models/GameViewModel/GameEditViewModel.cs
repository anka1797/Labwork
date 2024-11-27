using labworkWebApp.Models.Game;
using labworkWebApp.Models.GameGenre;

namespace labworkWebApp.Models.GameViewModel
{
    public class GameEditViewModel
    {
        public GameDto Game { get; set; }
        public List<GenreDto> Genres { get; set; }
    }
}
