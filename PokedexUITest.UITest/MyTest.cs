using NUnit.Framework;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace PokedexUITest.UITest
{
    [TestFixture(Platform.Android)]
    public class MyTest : Tests
    {
        #region Splash & Main view

        const string pokemonMainView = "pokemon_mainView";
        const string pokemonList = "poke_list_main";
        const string ButtonGoFavPokemonView = "fav_button_main";
        const string Splash = "splash_screen";
        const string favoritePokemon = "Favorte Pokemon";
        const string Bulbasaur = "bulbasaur";
        #endregion
        #region Details
        const string ButtonAddFavorite= "favpoke_save";
        const string PokemonDetailView = "pokemon_detailView";
        const string ButtonGoMoves = "btn_moves";
        const string ButtonGoAbilities = "btn_abilities";
        #endregion
        #region Favorite Pokemon
        const string FavoritePokemonView = "fav_pokemon_view";
        #endregion
        public MyTest(Platform platform) : base(platform)
        {}

        // aaa testing model
        [Test]
        public void firstTest()
        {
            //app.Screenshot($"{pokemonMainView} screen shot ");
            // ARRANGE

            //wait for main view

            app.WaitForElement(Splash, $"unable to load {Splash} ", TimeSpan.FromSeconds(1), null, null);
            app.WaitForElement (pokemonMainView, $"unable to load {pokemonMainView} ",TimeSpan.FromSeconds(5),null,null);
            
            //ACT 

            // if exist ButtonGoFavPokemonView
            var issp = app.Query(ButtonGoFavPokemonView).Any();
            app.Screenshot($"{ButtonGoFavPokemonView} screen shot ");
            Assert.IsTrue(issp, "Boton Pokemon favorito no encontrado");
            
            // tab element list Bulbasaur
            app.Tap(c => c.Marked(Bulbasaur));           
            app.WaitForElement(PokemonDetailView, $"unable to load {PokemonDetailView} ", TimeSpan.FromSeconds(15), null, null);


            var isbtnmoves = app.Query(ButtonGoMoves).Any();
            var isbtnabilities = app.Query(ButtonGoAbilities).Any();
            // OJO CON LOS ASSERTS 
            Assert.IsTrue(isbtnmoves, "Boton Pokemon Moves no encontrado");
            Assert.IsTrue(isbtnabilities, "Boton Pokemon Abilitites no encontrado");

            //add to favorite 
            app.Tap(c => c.Marked(ButtonAddFavorite));
            app.WaitForElement(PokemonDetailView, $"unable to load {PokemonDetailView} ", TimeSpan.FromSeconds(7), null, null);



            app.Back();


            //Scroll          
            app.ScrollDown(pokemonList,ScrollStrategy.Programmatically,.1,500,true);
            app.ScrollDown(pokemonList, ScrollStrategy.Programmatically, .10,500,true);
            app.WaitForElement(pokemonMainView, $"unable to load {pokemonMainView} ", TimeSpan.FromSeconds(5), null, null);

         

            //Go to favorites
            app.Tap(c => c.Marked(ButtonGoFavPokemonView));
            app.Tap(c => c.Marked(Bulbasaur));
            LaunchREPLTool();
            app.Tap(c => c.Marked("ok"));


            // Pokemon deleted

            app.WaitForElement(FavoritePokemonView, $"unable to load {FavoritePokemonView} ", TimeSpan.FromSeconds(9), null, null);
            app.Back();

            app.WaitForElement(pokemonMainView, $"unable to load {pokemonMainView} ", TimeSpan.FromSeconds(5), null, null);

            app.Tap(c => c.Marked(Bulbasaur));
            app.WaitForElement(PokemonDetailView, $"unable to load {PokemonDetailView} ", TimeSpan.FromSeconds(15), null, null);


            //Assert.IsTrue(isfav, "Hubo un error en vista Pokemon Favoritos");
        }


       // [Test]
        public void ScrollTest()
        {
            app.WaitForElement(pokemonMainView, $"unable to load {pokemonMainView} ", TimeSpan.FromSeconds(5), null, null);

            for (int i = 0; i < 21; i++)
            {
                app.ScrollDown(pokemonList, ScrollStrategy.Programmatically, 1, 3500, true);
            }
                        
            app.WaitForElement(pokemonMainView, $"unable to load {pokemonMainView} ", TimeSpan.FromSeconds(5), null, null);

        }
    }
}
