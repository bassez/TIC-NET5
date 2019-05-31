using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PiratesRhumStream.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int userId { get; set; }
        public string Description { get; set; }
        public DateTime Date_Publised { get; set; }
    }
}
