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

            AppCenter.Start("f382bc1a8a5f69e571cf99e9047f724a863c9581",
                   typeof(Analytics), typeof(Crashes));
            AppCenter.Start("f382bc1a8a5f69e571cf99e9047f724a863c9581",
                               typeof(Analytics), typeof(Crashes));
        }
    }
}
