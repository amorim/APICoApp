using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIFlooder.Models
{
    public class Usuario
    {
        public int id { get; set; }
        public string name { get; set; }
        public string photo { get; set; }
        public string bgPhoto { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public List<Interesse> interesses { get; set; }

    }
}