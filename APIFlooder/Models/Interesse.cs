using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIFlooder.Models
{
    public class Interesse
    {
        public int id { get; set; }
        public string description { get; set; }
        public override int GetHashCode()
        {
            return id;
        }
        public override bool Equals(object obj)
        {
            if (obj is Interesse)
            {
                return ((Interesse)obj).id == id;
            }
            return false;
        }
    }
}