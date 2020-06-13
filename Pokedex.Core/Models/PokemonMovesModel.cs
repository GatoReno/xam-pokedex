using System;
using System.Collections.Generic;
using System.Text;

namespace Pokedex.Core.Models
{
   public class PokemonMovesModel
    {
        public string Name { get; set; }
        public IList<MyMovesModel> AllMoves { get; set; }
    }
}
