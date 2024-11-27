using System.ComponentModel.DataAnnotations;

namespace labworkWebApp.Models
{
    public class GameModel
    {
        [Required(ErrorMessage = "Заполните поле названия")]
        [RegularExpression(@"^[а-яА-Яa-zA-Z1-10\s\-]{1,50}$", ErrorMessage = "Некорректный ввод названия")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Заполните поле Разарботчика")]
        [RegularExpression(@"^[а-яА-Яa-zA-Z1-10\s\-]{1,50}$", ErrorMessage = "Некорректный ввод разработчика")]
        public string Developer { get; set; }

        public string? Publisher { get; set; }
    }
}
