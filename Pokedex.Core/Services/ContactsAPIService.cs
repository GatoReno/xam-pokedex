using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pokedex.Core.Models;

namespace Pokedex.Core.Services
{
    public class ContactsAPIService : IContactService
    {
        public async Task<IList<Contact>> GetContacts()
        {
            //we should consume a web service
            await Task.Delay(TimeSpan.FromSeconds(3));
            var contacts = new List<Contact>();
            contacts.Add(new Contact()
            {
                Name = "Jose",
                LastName = "Palma"
            });

            contacts.Add(new Contact()
            {
                Name = "Pablo",
                LastName = "Jimenez"
            });

            contacts.Add(new Contact()
            {
                Name = "Joel",
                LastName = "Florez"
            });

            return contacts;
        }
    }
}
