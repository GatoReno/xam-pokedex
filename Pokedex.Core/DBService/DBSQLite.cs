using Pokedex.Core.Interfaces;
using Pokedex.Core.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Core.Services
{
    public class DBSQLite : IDBService
    {
        private bool initialized = false;
        internal static SQLiteAsyncConnection Database = null;

        public async Task Initialize(string path = "")
        {
            if (Database == null)
            {
                Database = new SQLiteAsyncConnection(path, SQLiteOpenFlags.Create | SQLiteOpenFlags.ReadWrite);
            }

            if (!initialized)
            {
                //we create table heres
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(PokemonDbModel).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(PokemonDbModel)).ConfigureAwait(false);
                    initialized = true;
                }
            }
        }
    }
}
