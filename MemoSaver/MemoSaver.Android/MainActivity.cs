using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using uuUtils.Droid;

namespace MemoSaver.Droid
{
    [Activity(Label = "MemoSaver", Icon = "@mipmap/icon", Theme = "@style/MainTheme", 
        /*MainLauncher = true,*/ ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        bool doubleBackToExitPressedOnce = false;
        App app;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            FileUtilsImpl.assets = this.Assets;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            app = new App();
            LoadApplication(app);
        }
        public void KeepScreenOn(bool isKeep)
        {
            if (isKeep)
            {
                Window.AddFlags(WindowManagerFlags.KeepScreenOn |
                    WindowManagerFlags.DismissKeyguard |
                    WindowManagerFlags.ShowWhenLocked |
                    WindowManagerFlags.TurnScreenOn);
            }
            else
            {
                Window.ClearFlags(WindowManagerFlags.KeepScreenOn |
                    WindowManagerFlags.TurnScreenOn);
            }
        }

        /*
        //public AlertDialog.Builder alert = null;
        public override void OnBackPressed()
        {
            if (!app.OnBack())
            {
                return;
            }
            if (doubleBackToExitPressedOnce)
            {
                //this.FinishAffinity();
                //System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
                base.OnBackPressed();
                Finish();
                //Java.Lang.JavaSystem.Exit(0);
                return;
            }

            this.doubleBackToExitPressedOnce = true;
            Toast.MakeText(this, "Press again to Exit...", ToastLength.Short).Show();

            new Handler().PostDelayed(() => {
                doubleBackToExitPressedOnce = false;
            }, 2000);
        }*/
    }
}