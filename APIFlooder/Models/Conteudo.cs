using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIFlooder.Models
{
    public class Conteudo
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string uri { get; set; }
        public Usuario criador { get; set; }
    }
}