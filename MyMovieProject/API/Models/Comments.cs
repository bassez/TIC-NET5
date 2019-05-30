using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Comments
    {
        public int Id { get; set; }
        public string Body { get; set; }

        // FK
        public Notes Notes { get; set; }
        public Comments CommentsChildren { get; set; }
    }
}
