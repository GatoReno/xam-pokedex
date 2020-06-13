using System;
using System.IO;
using Android.Widget;
using MvvmCross;
using MvvmCross.Base;
using MvvmCross.Droid.Support.V7.AppCompat;
using Pokedex.Core;
using Pokedex.Core.Interfaces;
using Pokedex.Core.Services;
using static System.Net.Mime.MediaTypeNames;

namespace Pokedex.Droid
{
    public class Setup : MvxAppCompatSetup<App>
    {
        protected override async void InitializeFirstChance()
        {
            base.InitializeFirstChance();
            var dbConnection = new DBSQLite();
            Mvx.IoCProvider.RegisterSingleton<IDBService>(dbConnection);

            var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var px = Path.Combine(basePath, "mi.db3");

            await dbConnection.Initialize(px);
            
        }

        //private async void OnInteractionRequested(object sender, MvxValueEventArgs<YesNoQuestion> eventArgs)
        //{
        //    var yesNoQuestion = eventArgs.Value;
        //    // show dialog
        //    Toast.MakeText(Application.Context, " ", ToastLength.Long).Show();  
        // }
    }
}
