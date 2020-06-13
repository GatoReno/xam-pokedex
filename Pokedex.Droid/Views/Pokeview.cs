using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using Pokedex.Core.Interfaces;
using Pokedex.Core.ViewModels;

namespace Pokedex.Droid.Views
{
    [MvxActivityPresentation]
    [Activity(Theme = "@style/AppTheme", MainLauncher = false)]
    public class Pokeview : MvxAppCompatActivity<PokeViewModel>
    {


        private MvxRecyclerView _recyclerView;
        private PaginationScrollListener _pokemonfeedPaging;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            //
            SetContentView(Resource.Layout.poke_view);

            var set = this.CreateBindingSet<Pokeview, PokeViewModel>();
            set.Bind(SupportActionBar).For(v => v.Title).To(vm => vm.Title);
            set.Apply();

            _pokemonfeedPaging = new PaginationScrollListener(ViewModel);
            _recyclerView = this.FindViewById<MvxRecyclerView>(Resource.Id.poke_list_main);
            _recyclerView.AddOnScrollListener(_pokemonfeedPaging);  

        }



        internal class PaginationScrollListener : MvxRecyclerView.OnScrollListener
        {            

            private IPagination _pagination;

            public PaginationScrollListener(IPagination viewModel)
            {
                
                _pagination = viewModel;
            }

            public override async void OnScrolled(RecyclerView recyclerView, int dx, int dy)
            {
                base.OnScrolled(recyclerView, dx, dy);

                var layoutManager = (LinearLayoutManager)recyclerView.GetLayoutManager();
                int firstVisibleItemPosition = layoutManager.FindFirstVisibleItemPosition();
                int currentItems = layoutManager.ItemCount / 2;
                if (firstVisibleItemPosition >= currentItems
                        && firstVisibleItemPosition >= 0)
                {
                    await _pagination.Next();
                }
            }
        }


        // end class
    }
}