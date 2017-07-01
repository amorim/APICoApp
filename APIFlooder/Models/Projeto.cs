using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIFlooder.Models
{
    public class Projeto : IComparable<Projeto>
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string image { get; set; }
        public Usuario criador { get; set; }
        public int usersOnProject { get; set; }
        public int views { get; set; }
        public List<Interesse> interesses { get; set; }
        public List<Usuario> usuarios { get; set; }
        public static Usuario userAtual;
        public int CompareTo(Projeto other)
        {
            List<Interesse> inter1 = userAtual.interesses.Intersect(interesses).ToList();
            List<Interesse> inter2 = userAtual.interesses.Intersect(other.interesses).ToList();
            if (inter1.Count > inter2.Count)
                return -1;
            if (inter1.Count < inter2.Count)
                return 1;
            if (views > other.views)
                return -1;
            if (views < other.views)
                return 1;
            return 0;
        }
        
    }
}