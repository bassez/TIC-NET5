using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Movies
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Publisher { get; set; }
        public string Type { get; set; }
        public int Length { get; set; }
        public string Image { get; set; }
        public DateTime Date_Publised { get; set; }

        public Notes Notes { get; set; }
        public Comments Comments { get; set; }
        public Likes Likes { get; set; }
    }
}
