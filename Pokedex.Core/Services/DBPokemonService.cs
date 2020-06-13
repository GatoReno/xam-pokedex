using Pokedex.Core.Interfaces;
using Pokedex.Core.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Core.Services
{
    public class DBPokemonService : IFavPokemonService
    {
        public async Task<bool> Add(PokemonDbModel poke)
        {
            try
            {
                await DBSQLite.Database.InsertAsync(poke);
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }
        public  bool GetPokemonLikeExist(string p)
        {
                     
            var pokes =  DBSQLite.Database.Table<PokemonDbModel>()
                .Where(pokes => pokes.Name.ToLower().StartsWith(p)).ToListAsync();


            var px = pokes.Result;
            if (px.Count() > 0) { return true; }
            else { return false; }

 
        }
        public async Task<IList<PokemonDbModel>> GetAllFavPokemon()
        {
            IList<PokemonDbModel> pokemons = null;
            try
            {
                pokemons = await DBSQLite.Database.Table<PokemonDbModel>().ToListAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            if (pokemons == null)
            {
                pokemons = new List<PokemonDbModel>();
            }

            return pokemons;
        }

        public bool DeletePokemon(PokemonDbModel poke)
        {
            
            
            var pokes =  DBSQLite.Database.DeleteAsync<PokemonDbModel>(poke.PrimaryKey);

            if (pokes.IsCompletedSuccessfully)
            {
                return true;

            }
            else
            {
                var e = pokes.Result;
                return false;

            }
        }
    }
}
