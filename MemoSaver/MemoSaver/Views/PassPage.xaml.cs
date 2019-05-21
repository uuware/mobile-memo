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
	public partial class PassPage : ExContentPage
    {
		public PassPage ()
		{
			InitializeComponent ();

            LoadCfg();

        }
        private void Gen_Clicked(object sender, EventArgs e)
        {
            int min = MinLen.Text.ToInt();
            if (min < 1)
            {
                min = 1;
                MinLen.Text = "" + min;
            }
            int max = MaxLen.Text.ToInt();
            if (max > 100)
            {
                max = 100;
                MaxLen.Text = "" + max;
            }
            if (min > max)
            {
                int t = min;
                min = max;
                max = t;
                MinLen.Text = "" + min;
                MaxLen.Text = "" + max;
            }
            string chars = null;
            if (ShowUpper.IsToggled)
            {
                chars += "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            }
            if (ShowLower.IsToggled)
            {
                chars += "abcdefghijklmnopqrstuvwxyz";
            }
            if (ShowNumber.IsToggled)
            {
                chars += "0123456789";
            }
            if (ShowSpecial.IsToggled)
            {
                chars += Special.Text.Trim();
            }
            string ret = StringUtils.GetRandomString(min, max, chars);
            Password.Text = ret;
            DependencyService.Get<IToast>().Show("Password is generated.");
        }

        private void Copy_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<IClipboard>().CopyToClipboard(Password.Text);
            DependencyService.Get<IToast>().Show("Password is copied.");
        }
        private void Cancel_Clicked(object sender, EventArgs e)
        {
            LoadCfg();
        }

        private void Save_Clicked(object sender, EventArgs e)
        {
            SaveCfg();
        }
        public void LoadCfg()
        {
            MinLen.Text = Cfg.SessionGet("MinLen", "8");
            MaxLen.Text = Cfg.SessionGet("MaxLen", "20");
            ShowPass.IsToggled = Cfg.SessionGet("ShowPass", false);
            ShowUpper.IsToggled = Cfg.SessionGet("ShowUpper", false);
            ShowLower.IsToggled = Cfg.SessionGet("ShowLower", false);
            ShowNumber.IsToggled = Cfg.SessionGet("ShowNumber", false);
            ShowSpecial.IsToggled = Cfg.SessionGet("ShowSpecial", false);
            Special.Text = Cfg.SessionGet("Special", "!@#$%^&*;:,.<>(){}\\/?-=");
            DependencyService.Get<IToast>().Show("Configuration is loaded.");
        }
        public void SaveCfg()
        {
            Cfg.SessionSet("MinLen", MinLen.Text.Trim());
            Cfg.SessionSet("MaxLen", MaxLen.Text.Trim());
            Cfg.SessionSet("ShowPass", ShowPass.IsToggled);
            Cfg.SessionSet("ShowUpper", ShowUpper.IsToggled);
            Cfg.SessionSet("ShowLower", ShowLower.IsToggled);
            Cfg.SessionSet("ShowNumber", ShowNumber.IsToggled);
            Cfg.SessionSet("ShowSpecial", ShowSpecial.IsToggled);
            Cfg.SessionSet("Special", Special.Text.Trim());
            DependencyService.Get<IToast>().Show("Configuration is saved.");
        }
    }
}