using Acr.UserDialogs;
using MvvmCross.Commands;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Pokedex.Core.Interfaces;
using Pokedex.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pokedex.Core.ViewModels
{
    public class PokeViewModel : MvxNavigationViewModel, IPagination
    {
        private string _title;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }


        private string _next;
        private string _previous;

        public string Previous
        {
            get => _previous;
            set => SetProperty(ref _previous, value);
        }
        public string Next
        {
            get => _next;
            set => SetProperty(ref _next, value);
        }


        private bool _isRefreshing;
        public bool IsRefreshing
        {
            get => _isRefreshing;
            set => SetProperty(ref _isRefreshing, value);
        }
        private readonly IUserDialogs _userDialogs;
        private readonly IPokemonService _pokemonService;
        private readonly IPokemonDetailService _pokemonDetailService;
        
              
        public IMvxAsyncCommand<PokemonModel> ItemSelectedCommand { get; set; }
        public IMvxAsyncCommand GoFavPokemonView { get; set; }
        public MvxAsyncCommand RefreshCommand { get; private set; }

        public MvxObservableCollection<PokemonModel> Pokemons { get; private set; }


        public PokeViewModel(
        IMvxLogProvider logProvider,
        IPokemonDetailService pokemondetail,
        IMvxNavigationService navigationService,
        IPokemonService pokemonservice,
        IUserDialogs userDialogs) : base(logProvider, navigationService)
        {
            _userDialogs = userDialogs;
            _pokemonService = pokemonservice;
            _pokemonDetailService = pokemondetail;
            Pokemons = new MvxObservableCollection<PokemonModel>();
            GoFavPokemonView = new MvxAsyncCommand(OnGoFavPokemonView);
            RefreshCommand = new MvxAsyncCommand(OnRefreshCommand);
            ItemSelectedCommand = new MvxAsyncCommand<PokemonModel>(OnItemSelectedCommand);
            Title = "PokeList";
            
           //Pokemons.CollectionChanged += Pokemons_CollectionChanged;
        }

        private void Pokemons_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
          //  throw new System.NotImplementedException();
        }

        private async Task OnGoFavPokemonView()
        {
            await NavigationService.Navigate<FavoritePokemonListViewModel>();

        }
        private async Task OnItemSelectedCommand(PokemonModel contact)
        {            
            _userDialogs.ShowLoading("Loading detail");           
            var detail = await _pokemonDetailService.GetPokemonDetail(contact.Url);
            _userDialogs.HideLoading();            
            await NavigationService.Navigate<PokemonDetailViewModel, PokemonDetailModel>(detail);
        }
        private async Task OnRefreshCommand()
        {
            IsRefreshing = true;
            Pokemons.Clear();
            await Initialize();
            IsRefreshing = false;
        }
        public override async Task Initialize()
        {
           await LoadPokemons();
        }

        private async Task LoadPokemons() {
            IEnumerable<PokemonModel> pokemons ;

            if (string.IsNullOrEmpty(Next))
            {
                 var pokemonList = await _pokemonService.GetPokemonsFromApi();
                  pokemons = pokemonList.PokeList;
                Previous = pokemonList.Previous;
                Next = pokemonList.Next;

            }
            else
            {
                var pokemonList = await _pokemonService.GetPokemonsChunck(Next);
                  pokemons = pokemonList.PokeList;
                Previous = pokemonList.Previous;
                Next = pokemonList.Next;

            }

           
            Pokemons.AddRange(pokemons);
            // GetPokemonsChunck

        }

        async Task IPagination.Next()
        {
            await LoadPokemons();
        }

        Task IPagination.Previous()
        {
             throw new System.NotImplementedException();
        }
    } 

}
