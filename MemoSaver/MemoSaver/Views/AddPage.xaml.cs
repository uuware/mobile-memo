using MemoSaver.Controls;
using MemoSaver.Services;
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
    public partial class AddPage : ExContentPage
    {
        ToolbarItem _toolDel;
        public AddPage()
        {
            InitializeComponent();

            _toolDel = toolDel;

        }
        async void OnBackClicked(object sender, EventArgs e)
        {
            //await Navigation.PopAsync();
            await Navigation.PopModalAsync();
        }
        async void OnSaveClicked(object sender, EventArgs e)
        {
            var item = (Item)BindingContext;
            item.Time = StringUtils.GetTimestamp(DateTime.Now, "yyyy-MM-dd HH:mm:ss");
            await App.Database.SaveItemAsync(item);
            await Navigation.PopModalAsync();
        }

        async void OnDeleteClicked(object sender, EventArgs e)
        {
            var answer = await DisplayAlert("Delete", "Do you really delete current record?", "Yes", "No");
            if (answer)
            {
                var item = (Item)BindingContext;
                await App.Database.DeleteItemAsync(item);
                await Navigation.PopModalAsync();
            }
        }

        public void HideToolAdd(bool show)
        {
            if (show && !ToolbarItems.Contains(_toolDel))
            {
                ToolbarItems.Insert(1, _toolDel);
                //Device.BeginInvokeOnMainThread(() => { ToolbarItems.Insert(0, _toolDel); });
            }
            else if (!show && ToolbarItems.Contains(_toolDel))
            {
                ToolbarItems.Remove(_toolDel);
            }
        }

        public void SetData()
        {
            var item = (Item)BindingContext;
            this.FieldT01.Text = Cfg.SessionGet("Field01", "Field 01");
            this.FieldT01.IsVisible = !String.IsNullOrEmpty(item.FieldT01) || Cfg.SessionGet("Field01S", 0) == 1;
            this.Field01.IsVisible = !String.IsNullOrEmpty(item.FieldT01) || Cfg.SessionGet("Field01S", 0) == 1;

            this.FieldT02.Text = Cfg.SessionGet("Field02", "Field 02");
            this.FieldT02.IsVisible = !String.IsNullOrEmpty(item.FieldT02) || Cfg.SessionGet("Field02S", 0) == 1;
            this.Field02.IsVisible = !String.IsNullOrEmpty(item.FieldT02) || Cfg.SessionGet("Field02S", 0) == 1;

            this.FieldT03.Text = Cfg.SessionGet("Field03", "Field 03");
            this.FieldT03.IsVisible = !String.IsNullOrEmpty(item.FieldT03) || Cfg.SessionGet("Field03S", 0) == 1;
            this.Field03.IsVisible = !String.IsNullOrEmpty(item.FieldT03) || Cfg.SessionGet("Field03S", 0) == 1;

            this.FieldT04.Text = Cfg.SessionGet("Field04", "Field 04");
            this.FieldT04.IsVisible = !String.IsNullOrEmpty(item.FieldT04) || Cfg.SessionGet("Field04S", 0) == 1;
            this.Field04.IsVisible = !String.IsNullOrEmpty(item.FieldT04) || Cfg.SessionGet("Field04S", 0) == 1;

            this.FieldT05.Text = Cfg.SessionGet("Field05", "Field 05");
            this.FieldT05.IsVisible = !String.IsNullOrEmpty(item.FieldT05) || Cfg.SessionGet("Field05S", 0) == 1;
            this.Field05.IsVisible = !String.IsNullOrEmpty(item.FieldT05) || Cfg.SessionGet("Field05S", 0) == 1;

            this.FieldT06.Text = Cfg.SessionGet("Field06", "Field 06");
            this.FieldT06.IsVisible = !String.IsNullOrEmpty(item.FieldT06) || Cfg.SessionGet("Field06S", 0) == 1;
            this.Field06.IsVisible = !String.IsNullOrEmpty(item.FieldT06) || Cfg.SessionGet("Field06S", 0) == 1;

            this.FieldT07.Text = Cfg.SessionGet("Field07", "Field 07");
            this.FieldT07.IsVisible = !String.IsNullOrEmpty(item.FieldT07) || Cfg.SessionGet("Field07S", 0) == 1;
            this.Field07.IsVisible = !String.IsNullOrEmpty(item.FieldT07) || Cfg.SessionGet("Field07S", 0) == 1;

            this.FieldT08.Text = Cfg.SessionGet("Field08", "Field 08");
            this.FieldT08.IsVisible = !String.IsNullOrEmpty(item.FieldT08) || Cfg.SessionGet("Field08S", 0) == 1;
            this.Field08.IsVisible = !String.IsNullOrEmpty(item.FieldT08) || Cfg.SessionGet("Field08S", 0) == 1;

            this.FieldT09.Text = Cfg.SessionGet("Field09", "Field 09");
            this.FieldT09.IsVisible = !String.IsNullOrEmpty(item.FieldT09) || Cfg.SessionGet("Field09S", 0) == 1;
            this.Field09.IsVisible = !String.IsNullOrEmpty(item.FieldT09) || Cfg.SessionGet("Field09S", 0) == 1;

            this.FieldT10.Text = Cfg.SessionGet("Field10", "Field 10");
            this.FieldT10.IsVisible = !String.IsNullOrEmpty(item.FieldT10) || Cfg.SessionGet("Field10S", 0) == 1;
            this.Field10.IsVisible = !String.IsNullOrEmpty(item.FieldT10) || Cfg.SessionGet("Field10S", 0) == 1;

            this.DoneT.IsVisible = "todo".Equals(item.Type);
            this.Done.IsVisible = "todo".Equals(item.Type);
        }
    }
}