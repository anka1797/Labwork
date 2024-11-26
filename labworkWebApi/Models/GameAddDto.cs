﻿using labworkData;
using System.ComponentModel.DataAnnotations.Schema;

namespace labworkWebApi.Models
{
    public class GameAddDto
    {
        public string Name { get; set; }
        public string Developer { get; set; }
        public string Publisher { get; set; }
        public string Category { get; set; }
        public string Access { get; set; }
        public int GenreId { get; set; }
    }
}
