using System;
using System.Collections.Generic;
using System.Text;

namespace Pokedex.Core.Models
{
    
    public class Result
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class PokemonCallApiModel
    {
        public int count { get; set; }
        public string next { get; set; }
        public string previous { get; set; }
        public IList<Result> results { get; set; }
    }
}
