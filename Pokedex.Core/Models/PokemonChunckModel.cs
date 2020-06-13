using System;
using System.Collections.Generic;
using System.Text;

namespace Pokedex.Core.Models
{
    public class PokemonChunckModel
    {
        public List<PokemonModel> PokeList { set; get; }
        public string Next { set; get; }
        public string Previous { set; get; }

        public string Message { set; get; }


    }
    
}
