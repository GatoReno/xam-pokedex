using Acr.UserDialogs;
using MvvmCross.Base;
using MvvmCross.Commands;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Pokedex.Core.Interfaces;
using Pokedex.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Core.ViewModels
{
    

    public class PokemonDetailViewModel : MvxNavigationViewModel, IMvxViewModel<PokemonDetailModel>//, IMvxViewModel<string>
    {
        private string _title;
        private string _link;

        private string _spriteSource;
        private readonly IUserDialogs _userDialogs;
        private readonly IFavPokemonService _pokemonfavService;
        private readonly IPokemonDetailService _pokemonDetailService;

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }
        public string Link
        {
            get => _link;
            set => SetProperty(ref _link, value);
        }

        private string _heightString;
        private string _weightString;
        private string _baseExp;
        public string BaseExpString
        {
            get => _baseExp;
            set => SetProperty(ref _baseExp, value);
        }
        public string HeightString
        {
            get => _heightString;
            set => SetProperty(ref _heightString, value);
        }
        public string WeightString
        {
            get => _weightString;
            set => SetProperty(ref _weightString, value);
        }
        public string SpriteSource
        {
            get => _spriteSource;
            set => SetProperty(ref _spriteSource, value);
        }

        //command
        public IMvxAsyncCommand ButtonFavPokemonClicked { get; set; }
        public IMvxAsyncCommand ButtonAbilitiesClicked { get; set; }
        public IMvxAsyncCommand ButtonMovesClicked { get; set; }

        
 

        public PokemonDetailModel Detail { get; private set; }


        //constructor
        public PokemonDetailViewModel(IMvxLogProvider logProvider,
            IUserDialogs userDialogs,
            IPokemonDetailService pokemondetail,
            IFavPokemonService pokemonFavService,
            IMvxNavigationService navigationService) : base(logProvider, navigationService)
        {
            _userDialogs = userDialogs;
            _pokemonfavService = pokemonFavService;            
            _pokemonDetailService = pokemondetail;
            ButtonFavPokemonClicked = new MvxAsyncCommand(OnButtonFavPokemonClicked);
            ButtonAbilitiesClicked = new MvxAsyncCommand(GoAbilities);
            ButtonMovesClicked = new MvxAsyncCommand(GoMoves);

  
        }

        public  bool FavoriteExist()
        {
          
                string poke = Detail.Name;
                bool exist =  _pokemonfavService.GetPokemonLikeExist(poke);
                return exist;
         }


        //end constructor




        //Checar esto 
        //interactions
        private MvxInteraction<string> _interaction = new MvxInteraction<string>();
        // set get imvinteraction
        public IMvxInteraction<string> EInteraction => _interaction;

 
        //end interactions

        //methods
       
        private async Task OnButtonFavPokemonClicked()
        {
            PokemonDbModel favpokemon = new PokemonDbModel();
            //favpokemon.Name = parameter.Stats[0];
            favpokemon.Name = Detail.Name;
            favpokemon.Url = Detail.Species.Url.ToString();
            favpokemon.Link = "https://img.pokemondb.net/artwork/" + Detail.Name + ".jpg";            
             var resp = await _pokemonfavService.Add(favpokemon);
            if (resp)
            {
                _interaction.Raise(Detail.Name);
            }
            else
            {
                TimeSpan interval = TimeSpan.FromSeconds(3);
                _userDialogs.Toast("hubo un Error no se puedo agrear a "+ Detail.Name, interval);
                    
            }

             

        }
      
        public async Task GoMoves()
        {
            _userDialogs.ShowLoading("Loading abilities info");
            var uri = Detail.Moves[0].MoveMove.Url.AbsoluteUri;
            List<MyMovesModel> mvx = new List<MyMovesModel>();


            foreach (var m in Detail.Moves)
            {
                MyMovesModel mim = new MyMovesModel();
                mim.Name = m.MoveMove.Name;
                mim.Url = m.MoveMove.Url.AbsoluteUri;
                mvx.Add(mim);
            }

            var nm = new PokemonMovesModel();
            nm.Name = Detail.Name;
            nm.AllMoves = mvx;


            await NavigationService.Navigate<MovesViewModel,PokemonMovesModel>(nm);

            _userDialogs.HideLoading();

        }
        private async Task GoAbilities()
        {
            _userDialogs.ShowLoading("Loading abilities info");

            IList<Ability> abi = new List<Ability>();

            foreach (var item in Detail.Abilities)
            {
                if (!item.IsHidden)
                {
                    abi.Add(item);
                }
                
            }

            var url = abi[0].AbilityAbility.Url.AbsoluteUri;
            PokemonAbilitiesModel abx = await  _pokemonDetailService.GetPokemonAbilities(url);             
            _userDialogs.HideLoading();

            await NavigationService.Navigate<AbilitiesViewModel,PokemonAbilitiesModel>(abx);
             //  Detail.Abilities[0];
        }


        //preprare , very important
        public void Prepare(PokemonDetailModel parameter)
        {
            Detail = parameter; //Url.AbsoluteUri
            Title = $"Pokemon : {parameter?.Name}";
            HeightString = $"Common height {parameter?.Height} cm";
            WeightString = $"Common weight {parameter?.Weight} cm";
            BaseExpString = $"Common base experience {parameter?.BaseExperience} xp";
            Link = "https://img.pokemondb.net/artwork/" + parameter?.Name + ".jpg";


        }



        public override void ViewAppearing()
        {
            base.ViewAppearing();

            //call service
        }
    }

}
