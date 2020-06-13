using Acr.UserDialogs;
using MvvmCross.Commands;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Pokedex.Core.Interfaces;
using Pokedex.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Core.ViewModels
{

    //list esta de mas
    public class FavoritePokemonListViewModel : MvxNavigationViewModel
    {
        private readonly IFavPokemonService _pokemonFavService;

        private readonly IUserDialogs _userDialogs;
        private string _title;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }
        public IMvxAsyncCommand DeletePokemon { get; set; }

        public MvxObservableCollection<PokemonDbModel> Pokemons { get; private set; }
        public IMvxAsyncCommand<string> SearchContactCommand { get; set; }
        public IMvxCommand SaveContactCommand { get; set; }
        public IMvxAsyncCommand<PokemonDbModel> ItemSelectedCommand { get; set; }

        public FavoritePokemonListViewModel(
              IMvxLogProvider logProvider,
              IMvxNavigationService navigationService,
              IFavPokemonService pokemonFavService,
              IUserDialogs userDialogs) : base(logProvider, navigationService)
         {
            _userDialogs = userDialogs;
            _pokemonFavService = pokemonFavService;
            Pokemons = new MvxObservableCollection<PokemonDbModel>();
              Title = "Favorite Pokemon";
            ItemSelectedCommand = new MvxAsyncCommand<PokemonDbModel>(OnItemSelectedCommand);
            SearchContactCommand = new MvxAsyncCommand<string>(OnSearchContactCommand);
            SaveContactCommand = new MvxCommand(OnSaveContactCommand);
 
        }

        private void OnSaveContactCommand()
        {
            //contact save
        }
        private async Task OnSearchContactCommand(string query)
        {
            //TODO: cache list! :O
            if (string.IsNullOrEmpty(query))
            {
                Pokemons.Clear();
                var pokemons = await _pokemonFavService.GetAllFavPokemon();
                Pokemons.AddRange(pokemons);
            }

            var contacts = Pokemons.Where(c => c.Name.Contains(query, StringComparison.CurrentCultureIgnoreCase)).ToList();
            Pokemons.Clear();
            Pokemons.AddRange(contacts);
        }

        private async Task OnItemSelectedCommand(PokemonDbModel pokemon)
        {
            TimeSpan interval = TimeSpan.FromSeconds(3);
            var x = await _userDialogs.ConfirmAsync("Do you want to delete "+ pokemon.Name + " from your favorites? 💙"
                ,"title"
                ,"ok","cancel");

            if (x)
            {
                try
                {
                    _pokemonFavService.DeletePokemon(pokemon);
                    Pokemons.Clear();
                    await Initialize();
                   _userDialogs.Toast(pokemon.Name+"  deleted " , interval);
                }
                catch (Exception error)
                {

                    _userDialogs.Toast("Erro , not deleted "+ error.ToString(),interval);
                }
                
               
            }
            else
            { }



        }

        public override async Task Initialize()
        {
            var pokemons = await _pokemonFavService.GetAllFavPokemon();
            Pokemons.AddRange(pokemons);
        }

    }
}
