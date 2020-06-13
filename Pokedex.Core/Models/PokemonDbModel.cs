using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pokedex.Core.Models
{
    public class PokemonDbModel : PokemonModel
    {
        [PrimaryKey, AutoIncrement]
        public int PrimaryKey { get; set; }
    }
}
