using MemoSaver.Controls;
using MemoSaver.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MemoSaver.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TodoPage : ExContentPage
    {
        AddPage addPage;
        public TodoPage ()
		{
			InitializeComponent ();

            addPage = new AddPage();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Reset the 'resume' id, since we just want to re-start here
            ((App)App.Current).ResumeAtTodoId = -1;
            listView.ItemsSource = await App.Database.GetItemsTypeAsync("todo");
            if (listView.ItemsSource.OfType<Item>().Count() > 0)
            {
                listView.IsVisible = true;
                labNodata.IsVisible = false;
            }
            else
            {
                listView.IsVisible = false;
                labNodata.IsVisible = true;
            }
        }

        async void OnItemAdded(object sender, EventArgs e)
        {
            //await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
            //await Navigation.PushAsync(addPage);
            Item item = new Item();
            item.Type = "todo";
            addPage.BindingContext = item;
            addPage.Title = "Add Todo";
            addPage.HideToolAdd(false);
            addPage.SetData();
            //await Navigation.PushAsync(addPage);
            await Navigation.PushModalAsync(new NavigationPage(addPage));
        }

        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                Item item = e.SelectedItem as Item;
                item.Type = "todo";
                addPage.BindingContext = item;
                addPage.Title = "Edit Todo";
                addPage.HideToolAdd(true);
                addPage.SetData();
                //await Navigation.PushAsync(addPage);
                await Navigation.PushModalAsync(new NavigationPage(addPage));
            }
        }
    }
}