using MemoSaver.Controls;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace MemoSaver.Views
{
    class TabMain : ExTabbedPage
    {
        private ExNavigationPage _listPage;
        private ExNavigationPage _todoPage;
        private ExNavigationPage _toolPage;
        private ExNavigationPage _setPage;

        public TabMain()
        {
            // place the bar at bottom
            On<Xamarin.Forms.PlatformConfiguration.Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
            On<Xamarin.Forms.PlatformConfiguration.Android>().SetBarSelectedItemColor(Color.FromHex("555555")); //3C9BDF
            On<Xamarin.Forms.PlatformConfiguration.Android>().SetBarItemColor(Color.Gray);
            this.BarBackgroundColor = Color.FromHex("ff0000");
            this.BackgroundColor = Color.White;
            this.BarTextColor = Color.Gray;

            _listPage = new ExNavigationPage(new ListPage());
            _todoPage = new ExNavigationPage(new TodoPage());
            _toolPage = new ExNavigationPage(new PassPage());
            _setPage = new ExNavigationPage(new SetPage());

            _listPage.Icon = "note.png";
            _listPage.Title = "Memo";
            _listPage.BackgroundColor = Color.White;
            _todoPage.Icon = "check.png";
            _todoPage.Title = "Todo";
            _todoPage.BackgroundColor = Color.White;
            _toolPage.Icon = "genpass.png";
            _toolPage.Title = "Tool";
            _toolPage.BackgroundColor = Color.White;
            _setPage.Icon = "setting.png";
            _setPage.Title = "Settings";
            _setPage.BackgroundColor = Color.White;

            Children.Add(_listPage);
            Children.Add(_todoPage);
            Children.Add(_toolPage);
            Children.Add(_setPage);
            CurrentPage = _listPage;
        }

        public void ResetToVaultPage()
        {
            CurrentPage = _listPage;
        }

        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();

            /*if (CurrentPage.Title == "App")
            {
                _listPage.Icon = "app_logo.png";
            }
            else
            {
                _listPage.Icon = "app_logo_unselected.png";
            }*/
            this.Title = CurrentPage.Title;
        }
    }
}
