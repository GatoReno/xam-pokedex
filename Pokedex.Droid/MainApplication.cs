using System;
using Acr.UserDialogs;
using Android.App;
using Android.Runtime;
using Android.Widget;
using MvvmCross.Base;
using MvvmCross.Droid.Support.V7.AppCompat;
using Pokedex.Core;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Firebase;
using Firebase.Database;

namespace Pokedex.Droid
{
    [Application]
    public class MainApplication : MvxAppCompatApplication<Setup, App>
    {
        public MainApplication(IntPtr handle, JniHandleOwnership transer)
        : base(handle, transer)
        {
        }

      
        public override void OnCreate()
        {
            base.OnCreate();
            //intialize all plugins
            UserDialogs.Init(this);

            //App Center
            AppCenter.Start("f382bc1a8a5f69e571cf99e9047f724a863c9581",
                   typeof(Analytics), typeof(Crashes));


            //Fire base
            FirebaseApp.InitializeApp(this);

            var i = FirebaseDatabase.Instance;
            var tryme = i.GetReference("users");
            var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("users");
            collection.
            //FirebaseClient firebase = new FirebaseClient("https://xamarinfirebase-xxxxx.firebaseio.com/");
            //tryme.LimitToLast(1);
            // tryme.SetValue("first try");
            tryme.OrderByValue();
        }
    }
}
