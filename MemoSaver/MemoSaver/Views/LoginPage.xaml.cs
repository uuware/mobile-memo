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
    public partial class LoginPage : ExContentPage
    {
        private SetPage setPage;
        private string pass;
        public LoginPage()
        {
            InitializeComponent();
        }

        public async void Login_Clicked(object sender, EventArgs e)
        {
            if (setPage != null && !string.IsNullOrEmpty(pass))
            {
                if (Password.Text.Trim().Equals(pass))
                {
                    setPage.Callback_LoginPage();
                    await Navigation.PopModalAsync();
                }
                else
                {
                    DependencyService.Get<IToast>().Show("Password is wrong.");
                }
            }
            else
            {
                string passSaved = Cfg.SessionGet("Password", "");
                if (string.IsNullOrEmpty(passSaved) || Password.Text.Trim().Equals(passSaved))
                {
                    Application.Current.MainPage = new TabMain();
                }
                else
                {
                    DependencyService.Get<IToast>().Show("Password is wrong.");
                }
            }
        }
        public async void Cancel_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<IToast>().Show("Configuration is not saved yet.");
            await Navigation.PopModalAsync();
        }
        public void test(string pass, SetPage setPage)
        {
            this.pass = pass;
            this.setPage = setPage;
            labTitle.Text = "Test Password";
            btnCancel.IsVisible = true;
            btnLogin.HorizontalOptions = LayoutOptions.EndAndExpand;
        }
    }
}