using System;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Pokedex.Core.Models;

namespace Pokedex.Core.ViewModels
{
    public class ContactDetailViewModel : MvxNavigationViewModel, IMvxViewModel<Contact>, IMvxViewModel<string>
    {
        private string _title;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public Contact Contact { get; private set; }

        public ContactDetailViewModel(IMvxLogProvider logProvider,
            IMvxNavigationService navigationService) : base(logProvider, navigationService)
        {

        }

        public void Prepare(Contact parameter)
        {
            Contact = parameter;
            Title = $"Contacts: {parameter?.Name}";
        }

        public void Prepare(string parameter)
        {
            Contact = new Contact();
            Title = parameter;
        }
    }
}
