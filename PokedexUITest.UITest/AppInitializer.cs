using System;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace PokedexUITest.UITest
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
                return ConfigureApp.Android
                    //.ApkFile("../../../Pokedex.Droid/bin/Release/com.elevensource.pokedextraining.pokedex-Signed.apk")
                    .InstalledApp("com.elevensource.pokedextraining.pokedex")
                    .EnableLocalScreenshots()
                    .StartApp();
            }

            return ConfigureApp.iOS.StartApp();
        }
    }
}