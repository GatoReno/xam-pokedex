using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Core.Models
{
    public class PokemonHttpCallerModel
    {
      
        public async Task<PokemonChunckModel> GetPokemon(string u) 
        {
        var next = "";
        var previous = "";
        var pokemons = new List<PokemonModel>();
            string msn;
            PokemonChunckModel chunck = new PokemonChunckModel();
            HttpCaller caller = new HttpCaller();
            var resp = await caller.GetMethod(u);

            try
            {
                var json_d = JsonConvert.DeserializeObject<PokemonCallApiModel>(resp);
                if (json_d.count > 0)
                {
                    next = json_d.next;
                    previous = json_d.previous;
                    msn = "success";
                    foreach (var Result in json_d.results)
                    {
                        pokemons.Add(new PokemonModel()
                        {
                            Name = Result.name,
                            Url = Result.url,
                            Link = "https://img.pokemondb.net/artwork/" + Result.name + ".jpg"
                        });
                    }
                }
                else
                {
                    msn = "No hay pokemon en la cuenta api";
                }
            }
            catch (Exception ex)
            {
                msn = "Error";
                Console.WriteLine("ERROR---------------------------- " + ex.Message + " // " + ex.ToString());

            }

            chunck.PokeList = pokemons;
            chunck.Next = next;
            chunck.Previous = previous;
            chunck.Message = msn;

            return chunck;

        }
    }
}
