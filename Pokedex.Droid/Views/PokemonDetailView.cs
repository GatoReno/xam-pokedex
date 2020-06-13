using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Javax.Security.Auth;
using MvvmCross.Base;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using MvvmCross.ViewModels;
using Pokedex.Core.ViewModels;
using static Android.Support.V7.Widget.SearchView;

namespace Pokedex.Droid.Views
{
    

    [MvxActivityPresentation]
    [Activity(Theme = "@style/AppTheme")]
    public class PokemonDetailView : MvxAppCompatActivity<PokemonDetailViewModel>,        
        IMenuItemOnActionExpandListener
    {


        private IMvxInteraction<string> _errorInteraction;
        public IMvxInteraction<string> ErrorInteraction
        {
            get => _errorInteraction;

            set
            {
                if (_errorInteraction != null)
                {
                    _errorInteraction.Requested -= OnSqliteInteraction;
                }

                _errorInteraction = value;
                _errorInteraction.Requested += OnSqliteInteraction;
            }
        }

        private void OnSqliteInteraction(object sender, MvxValueEventArgs<string> e)
        {
         
            var toast = Toast.MakeText(ApplicationContext, " 💜 "+e.Value+" add to your favorite pokemon list", ToastLength.Short);
            
            toast.Show();
        }


        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            //  ViewModel.ButtonFavPokemonClicked.Execute();
            MenuInflater.Inflate(Resource.Menu.details_menu, menu);
            var buttonmenu = menu.FindItem(Resource.Id.favpoke_save);
            bool exist =  ViewModel.FavoriteExist();
            if (exist)
            {
                buttonmenu.SetTitle("💙");
            }
            else {

                buttonmenu.SetTitle(" ADD 💙");
            }         
            //no async call from vm isfavoritemethod?
           
            //get id de bton de mi menu 
            return base.OnCreateOptionsMenu(menu);

        }


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.pokemon_detail_view);

            //create bindings manually
            var set = this.CreateBindingSet<PokemonDetailView, PokemonDetailViewModel>();
            set.Bind(SupportActionBar).For(v => v.Title).To(vm => vm.Title);
            set.Bind(this).For(v => v.ErrorInteraction).To(vm => vm.EInteraction);


            

            set.Apply();
        }





        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.favpoke_save:
                    ViewModel.ButtonFavPokemonClicked.Execute();
                    return true;
                default:
                    return base.OnOptionsItemSelected(item);

            }
        }

        public bool OnMenuItemActionCollapse(IMenuItem item)
        {
            return true;
        }

        public bool OnMenuItemActionExpand(IMenuItem item)
        {
            return true;
        }

    }
}