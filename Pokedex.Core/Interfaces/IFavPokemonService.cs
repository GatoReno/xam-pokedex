using Pokedex.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Core.Interfaces
{
    public interface IFavPokemonService
    {
        public Task<IList<PokemonDbModel>> GetAllFavPokemon();
        public Task<bool> Add(PokemonDbModel poke);
        public bool DeletePokemon(PokemonDbModel poke);
        public bool GetPokemonLikeExist(string p);

    }
}
