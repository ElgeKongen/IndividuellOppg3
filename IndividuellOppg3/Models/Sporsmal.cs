using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndividuellOppg3.Models
{
    public class Sporsmal
    {
        public int Id { get; set; }
        public string Spm { get; set; }
        
        public int Liker { get; set; }
        public int LikerIkke { get; set; }
        public string Svr { get; set; }

         
    }
}
