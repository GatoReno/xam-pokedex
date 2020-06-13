using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pokedex.Core.Models;

namespace Pokedex.Core.Services
{
    public class ContactsService : IContactService
    {
        public async Task<IList<Contact>> GetContacts()
        {
            var contacts = new List<Contact>();
            contacts.Add(new Contact()
            {
                Name = "Jair",
                LastName = "Palma"
            });

            contacts.Add(new Contact()
            {
                Name = "Jose Luis",
                LastName = "Jimenez"
            });


            contacts.Add(new Contact()
            {
                Name = "Paola",
                LastName = "Florez"
            });

            return await Task.FromResult(contacts);
        }
    }

    //714
}
