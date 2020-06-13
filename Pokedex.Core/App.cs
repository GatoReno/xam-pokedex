using System;
using Acr.UserDialogs;
using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.ViewModels;
using Pokedex.Core.Interfaces;
using Pokedex.Core.Services;
using Pokedex.Core.ViewModels;

namespace Pokedex.Core
{
    public class App : MvxApplication
    {
        /// <summary>
        /// Breaking change in v6: This method is called on a background thread. Use
        /// Startup for any UI bound actions
        /// </summary>
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();


            Mvx.IoCProvider.RegisterSingleton<IUserDialogs>(UserDialogs.Instance);
            //we register the interface
            Mvx.IoCProvider.LazyConstructAndRegisterSingleton<IFavPokemonService, DBPokemonService>();
            Mvx.IoCProvider.LazyConstructAndRegisterSingleton<IPokemonDetailService, PokemonDetailService>();
            Mvx.IoCProvider.LazyConstructAndRegisterSingleton<IContactService, ContactsService>();

            RegisterAppStart<PokeViewModel>();
        }
    }
}
