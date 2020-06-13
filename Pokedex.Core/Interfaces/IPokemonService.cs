using Pokedex.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Core
{
   

    public interface IPokemonService
    {
        Task<PokemonChunckModel> GetPokemonsFromApi();
        Task<PokemonChunckModel> GetPokemonsChunck(string u);

    }

}
