using System;
using System.Diagnostics;
using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Pokedex.Core.Models;
using Pokedex.Core.Services;

namespace Pokedex.Core.ViewModels
{
    public class ContactsViewModel : MvxNavigationViewModel
    {

        private string _title;

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        private readonly IContactService _contactService;

        public ContactsViewModel(
            IMvxLogProvider logProvider,
            IMvxNavigationService navigationService,
            IContactService contactService) : base(logProvider, navigationService)
        {
            _contactService = contactService;
            Contacts = new MvxObservableCollection<Contact>();
            ItemSelectedCommand = new MvxAsyncCommand<Contact>(OnItemSelectedCommand);
            Title = "Contacts";
        }

        public MvxObservableCollection<Contact> Contacts { get; private set; }
        public IMvxAsyncCommand<Contact> ItemSelectedCommand { get; set; }
       

        private async Task OnItemSelectedCommand(Contact contact)
        {
           //await NavigationService.Navigate<ContactDetailViewModel, string>("");
           await NavigationService.Navigate<ContactDetailViewModel, Contact>(contact);
        }

        public override async Task Initialize()
        {
            var contacts = await _contactService.GetContacts();

            Contacts.AddRange(contacts);
        }
    }
   
}
