using MvvmCross.Base;
using Newtonsoft.Json;
using Pokedex.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Core.Services
{
    public class PokemonApiService : IPokemonService
    {
        public string next;
        public string previous;
          
        public async Task<PokemonChunckModel> GetPokemonsFromApi()
        {
            var uri = "https://pokeapi.co/api/v2/pokemon/";


            //PokemonHttpCallerModel caller = new PokemonHttpCallerModel();
            PokemonChunckModel chunck = await GetPokemonsChunck(uri);
            //await caller.GetPokemon(uri);

            chunck.PokeList = chunck.PokeList;
            chunck.Next = chunck.Next;
            chunck.Previous = chunck.Previous;
            chunck.Message = chunck.Message;

            return chunck;
        }

        public async Task<PokemonChunckModel> GetPokemonsChunck(string u)
        {
            PokemonHttpCallerModel caller = new PokemonHttpCallerModel();
            PokemonChunckModel chunck = await caller.GetPokemon(u);

            chunck.PokeList = chunck.PokeList;
            chunck.Next = chunck.Next;
            chunck.Previous = chunck.Previous;
            chunck.Message = chunck.Message;

            return chunck;
        }

        //public async Task<PokemonChunckModel> GetPokemonsFromApi()
        //{
        //    var uri = "https://pokeapi.co/api/v2/pokemon/";
        //    string msn;
        //    HttpClient client = new HttpClient();
        //    var respPokeApi = await client.GetAsync(uri);
        //    var pokemons = new List<PokemonModel>();

        //    if (respPokeApi.IsSuccessStatusCode)
        //    {
        //        var respContent = await respPokeApi.Content.ReadAsStringAsync();
        //        var json_d = JsonConvert.DeserializeObject<PokemonCallApiModel>(respContent);

        //        next = json_d.next;
        //        previous = json_d.previous;
        //        msn = "success";

        //        foreach (var Result in json_d.results)
        //        {
        //            pokemons.Add(new PokemonModel()
        //            {
        //                Name = Result.name,
        //                Url = Result.url,
        //                Link = "https://img.pokemondb.net/artwork/" + Result.name + ".jpg"
        //            });
        //        }
        //    }
        //    else
        //    {
        //        msn = await respPokeApi.Content.ReadAsStringAsync();
        //    }

        //    PokemonChunckModel chunck = new PokemonChunckModel();
        //    chunck.PokeList = pokemons;
        //    chunck.Next = next;
        //    chunck.Previous = previous;
        //    chunck.Message = msn;

        //    return chunck;
        //}

        //public async Task<PokemonChunckModel> GetPokemonsChunck(string uri)
        //{

        //    string msn;
        //    HttpClient client = new HttpClient();
        //    var respPokeApi = await client.GetAsync(uri);
        //    var pokemons = new List<PokemonModel>();

        //    if (respPokeApi.IsSuccessStatusCode)
        //    {
        //        var respContent = await respPokeApi.Content.ReadAsStringAsync();
        //        var json_d = JsonConvert.DeserializeObject<PokemonCallApiModel>(respContent);

        //        next = json_d.next;
        //        previous = json_d.previous;
        //        msn = "success";

        //        foreach (var Result in json_d.results)
        //        {
        //            pokemons.Add(new PokemonModel()
        //            {
        //                Name = Result.name,
        //                Url = Result.url,
        //                Link = "https://img.pokemondb.net/artwork/" + Result.name + ".jpg"
        //            });
        //        }
        //    }
        //    else
        //    {
        //        msn = await respPokeApi.Content.ReadAsStringAsync();
        //    }

        //    PokemonChunckModel chunck = new PokemonChunckModel();
        //    chunck.PokeList = pokemons;
        //    chunck.Next = next;
        //    chunck.Previous = previous;
        //    chunck.Message = msn;

        //    return chunck;
        //}
    }
}
