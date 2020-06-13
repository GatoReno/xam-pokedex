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
using MvvmCross.Binding.BindingContext;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using Pokedex.Core.ViewModels;
using static Android.Support.V7.Widget.SearchView;

namespace Pokedex.Droid.Views
{
    [MvxActivityPresentation]
    [Activity(Theme = "@style/AppTheme", MainLauncher = false)]

    public class FavoritePokemonView : MvxAppCompatActivity<FavoritePokemonListViewModel>,
        IOnQueryTextListener,
    IMenuItemOnActionExpandListener

    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            //
            SetContentView(Resource.Layout.favorite_poke);

            var set = this.CreateBindingSet<FavoritePokemonView, FavoritePokemonListViewModel>();
            set.Bind(SupportActionBar).For(v => v.Title).To(vm => vm.Title);
            set.Apply();
        }


        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.favpoke_menu, menu);


            IMenuItem searchItem = menu.FindItem(Resource.Id.fav_search);
            var searchView = searchItem.ActionView as Android.Support.V7.Widget.SearchView;
            searchView.SetOnQueryTextListener(this);
            

            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.favpoke_save:
                    ViewModel.SaveContactCommand.Execute();
                    return true;
                default:
                    return base.OnOptionsItemSelected(item);

            }
        }

        public bool OnQueryTextChange(string newText)
        {
            ViewModel.SearchContactCommand.Execute(newText);
            return true;
        }

        public bool OnQueryTextSubmit(string newText)
        {
            ViewModel.SearchContactCommand.Execute(newText);
            return true;
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