using MemoSaver.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uuUtils;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MemoSaver.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SetPage : ExContentPage
    {
        public SetPage()
        {
            InitializeComponent();

            LoadCfg();

        }

        public void LoadCfg()
        {
            IsLogin.IsToggled = Cfg.SessionGet("IsLogin", false);

            Field01.Text = Cfg.SessionGet("Field01", "");
            Field01S.IsToggled = Cfg.SessionGet("Field01S", false);
            Field02.Text = Cfg.SessionGet("Field02", "");
            Field02S.IsToggled = Cfg.SessionGet("Field02S", false);
            Field03.Text = Cfg.SessionGet("Field03", "");
            Field03S.IsToggled = Cfg.SessionGet("Field03S", false);
            Field04.Text = Cfg.SessionGet("Field04", "");
            Field04S.IsToggled = Cfg.SessionGet("Field04S", false);
            Field05.Text = Cfg.SessionGet("Field05", "");
            Field05S.IsToggled = Cfg.SessionGet("Field05S", false);
            Field06.Text = Cfg.SessionGet("Field06", "");
            Field06S.IsToggled = Cfg.SessionGet("Field06S", false);
            Field07.Text = Cfg.SessionGet("Field07", "");
            Field07S.IsToggled = Cfg.SessionGet("Field07S", false);
            Field08.Text = Cfg.SessionGet("Field08", "");
            Field08S.IsToggled = Cfg.SessionGet("Field08S", false);
            Field09.Text = Cfg.SessionGet("Field09", "");
            Field09S.IsToggled = Cfg.SessionGet("Field09S", false);
            Field10.Text = Cfg.SessionGet("Field10", "");
            Field10S.IsToggled = Cfg.SessionGet("Field10S", false);
            DependencyService.Get<IToast>().Show("Configuration is loaded.");
        }
        public void SaveCfg()
        {
            if (!string.IsNullOrEmpty(Password.Text.Trim()))
            {
                Cfg.SessionSet("Password", Password.Text.Trim());
            }
            Cfg.SessionSet("IsLogin", IsLogin.IsToggled);

            Cfg.SessionSet("Field01", Field01.Text);
            Cfg.SessionSet("Field01S", Field01S.IsToggled);
            Cfg.SessionSet("Field02", Field02.Text);
            Cfg.SessionSet("Field02S", Field02S.IsToggled);
            Cfg.SessionSet("Field03", Field03.Text);
            Cfg.SessionSet("Field03S", Field03S.IsToggled);
            Cfg.SessionSet("Field04", Field04.Text);
            Cfg.SessionSet("Field04S", Field04S.IsToggled);
            Cfg.SessionSet("Field05", Field05.Text);
            Cfg.SessionSet("Field05S", Field05S.IsToggled);
            Cfg.SessionSet("Field06", Field06.Text);
            Cfg.SessionSet("Field06S", Field06S.IsToggled);
            Cfg.SessionSet("Field07", Field07.Text);
            Cfg.SessionSet("Field07S", Field07S.IsToggled);
            Cfg.SessionSet("Field08", Field08.Text);
            Cfg.SessionSet("Field08S", Field08S.IsToggled);
            Cfg.SessionSet("Field09", Field09.Text);
            Cfg.SessionSet("Field09S", Field09S.IsToggled);
            Cfg.SessionSet("Field10", Field10.Text);
            Cfg.SessionSet("Field10S", Field10S.IsToggled);
            DependencyService.Get<IToast>().Show("Configuration is saved.");
        }

        private void Cancel_Clicked(object sender, EventArgs e)
        {
            LoadCfg();
        }

        private async void Save_Clicked(object sender, EventArgs e)
        {
            string pass = Password.Text.Trim();
            if (string.IsNullOrEmpty(pass))
            {
                pass = Cfg.SessionGet("Password", "");
            }
            if (IsLogin.IsToggled && !string.IsNullOrEmpty(pass) && Cfg.SessionGet("IsLogin", 0) == 0)
            {
                var login = new LoginPage();
                login.test(pass, this);
                await Navigation.PushModalAsync(new NavigationPage(login));
            }
            else
            {
                SaveCfg();
            }
        }
        public void Callback_LoginPage()
        {
            SaveCfg();
        }
    }
}