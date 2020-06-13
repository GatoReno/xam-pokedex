using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pokedex.Core.Models;

namespace Pokedex.Core
{
    public interface IContactService
    {
        Task<IList<Contact>> GetContacts();
    }
}
