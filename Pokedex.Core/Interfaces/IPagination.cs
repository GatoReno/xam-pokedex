using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Core.Interfaces
{
    public interface IPagination
    {
        public  Task Next();
        public Task Previous();
    }
}
