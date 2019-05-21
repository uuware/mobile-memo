using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific.AppCompat;

namespace MemoSaver.Controls
{
    public class ExNavigationPage : Xamarin.Forms.NavigationPage
    {
        public ExNavigationPage()
            : base()
        {
            SetDefaults();
        }

        public ExNavigationPage(Page root)
            : base(root)
        {
            SetDefaults();
        }

        private void SetDefaults()
        {
            // default colors for our app
            BarBackgroundColor = Color.White; // Color.FromHex("3c8dbc");
            BarTextColor = Color.Black;
            On<Android>().SetBarHeight(140);
        }
    }
}
