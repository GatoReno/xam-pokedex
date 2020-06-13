using Acr.UserDialogs;
using MvvmCross.Commands;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Pokedex.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Core.ViewModels
{
   public class MovesViewModel : MvxViewModel, IMvxViewModel<PokemonMovesModel> 
    {
        private readonly IUserDialogs _userDialogs;
        private readonly IPokemonDetailService _pokemonDetailService;

        public IMvxAsyncCommand<MyMovesModel> ItemSelectedCommand { get; set; }

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }
         private string _title;
        private string _link;
        public MvxObservableCollection<MyMovesModel> PokemonMoves { get; private set; }
        public string Link
        {
            get => _link;
            set => SetProperty(ref _link, value);
        }

        public MovesViewModel(IUserDialogs userDialogs
            , IPokemonDetailService pokemondetail) 
        {
            _userDialogs = userDialogs;
            _pokemonDetailService = pokemondetail;
            ItemSelectedCommand = new MvxAsyncCommand<MyMovesModel>(OnItemSelectedCommand);

            PokemonMoves = new MvxObservableCollection<MyMovesModel>();

        }

        private async Task OnItemSelectedCommand(MyMovesModel pokemonMove)
        {
            var uri = pokemonMove.Url;
            _userDialogs.ShowLoading("Loading move's detail");

            var mv = await _pokemonDetailService.GetPokemonMovesDetail(uri);
            await  _userDialogs.AlertAsync(
                mv
                ,"Move : "+pokemonMove.Name
                ,"Ok");

            _userDialogs.HideLoading();

        }

        public void Prepare(PokemonMovesModel parameter)
        {

            Title = $" {parameter?.Name} Moves 🎲⚔🔥💧⚡";
            PokemonMoves.AddRange(parameter?.AllMoves);
            Link = "https://img.pokemondb.net/artwork/" + parameter?.Name + ".jpg";
        }
    }
}
