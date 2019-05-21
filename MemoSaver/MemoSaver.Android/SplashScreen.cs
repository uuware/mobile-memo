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
using Android.Content.PM;

namespace MemoSaver.Droid
{
    [Activity(Label = "My Memo"
        , MainLauncher = true
        /*, Icon = "@drawable/icon"*/
        , NoHistory = true
        , Theme = "@style/Theme.SplashScreen"
        , ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class SplashScreen : Activity {
        protected override void OnCreate(Bundle bundle) {
            Window.SetFlags(WindowManagerFlags.Fullscreen, WindowManagerFlags.Fullscreen);
            RequestWindowFeature(WindowFeatures.NoTitle);

            base.OnCreate(bundle);
            var intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
            //Finish();
        }
    }
}