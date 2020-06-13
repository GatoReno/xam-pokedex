using Newtonsoft.Json;
using Pokedex.Core.Models;
using QuickType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Core.Services
{
    public class PokemonDetailService : IPokemonDetailService
    {

        public async Task<PokemonAbilitiesModel>  GetPokemonAbilities(string v)
        {
            var uri = v;
            HttpClient client = new HttpClient();
            var respPokeApi = await client.GetAsync(uri);
            var pokemonAbilities = new PokemonAbilitiesModel();
            if (respPokeApi.IsSuccessStatusCode)
            {
                var respContent = await respPokeApi.Content.ReadAsStringAsync();
                pokemonAbilities = JsonConvert.DeserializeObject<PokemonAbilitiesModel>(respContent);

            }

            return pokemonAbilities;
        }
        public async Task<PokemonDetailModel> GetPokemonDetail(string u)
        {
            var uri = u;
            HttpClient client = new HttpClient();
            var respPokeApi = await client.GetAsync(uri);
            var pokemondetail = new PokemonDetailModel();

            if (respPokeApi.IsSuccessStatusCode)
            {
                var respContent = await respPokeApi.Content.ReadAsStringAsync();
                pokemondetail = JsonConvert.DeserializeObject<PokemonDetailModel>(respContent);

             }

            return pokemondetail;
        }
        public async Task<string> GetPokemonMovesDetail(string u) {

            var uri = u;
            string s;
            HttpClient client = new HttpClient();
            var respPokeApi = await client.GetAsync(uri);
            var pokemonmoves = new MoveData();

            if (respPokeApi.IsSuccessStatusCode)
            {
                var respContent = await respPokeApi.Content.ReadAsStringAsync();
                pokemonmoves = JsonConvert.DeserializeObject<MoveData>(respContent);

                 s = pokemonmoves.ContestType.Name.ToString()
                    + " :  " + pokemonmoves.DamageClass.Name.ToString()
                    + " : " + pokemonmoves.EffectEntries[0].Effect.ToString() + " : "
                    + pokemonmoves.FlavorTextEntries[2].FlavorText.ToString();

            }
            else { s = "No data found."; }

            return s;
        }



    }
}
