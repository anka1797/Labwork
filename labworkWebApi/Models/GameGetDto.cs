using labworkData;
using System.ComponentModel.DataAnnotations.Schema;

namespace labworkWebApi.Models
{
    public class GameGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Developer { get; set; }
        public string? Publisher { get; set; }
        public string? Category { get; set; }
        public string FullCompany {  get; set; }
        public string GenreName { get; set; }
    }
}
