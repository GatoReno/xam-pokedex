using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Core.Interfaces
{
    public   interface IDBService
    {
        public Task Initialize(string path = "");
    }
}
