using Pokedex.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Core
{
    public interface IPokemonDetailService
    {
        Task<PokemonDetailModel> GetPokemonDetail(string u);

        Task<PokemonAbilitiesModel> GetPokemonAbilities(string v);

        Task<string> GetPokemonMovesDetail(string v);
    }
}
