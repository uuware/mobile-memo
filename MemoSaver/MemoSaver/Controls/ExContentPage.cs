using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MemoSaver.Controls
{
    public class ExContentPage : ContentPage
    {
        private bool _syncIndicator;
        private bool _updateActivity;
        private bool _requireAuth;

        public ExContentPage()
        {
        }

        public ExContentPage(bool syncIndicator = false, bool updateActivity = true, bool requireAuth = true)
        {
            _syncIndicator = syncIndicator;
            _updateActivity = updateActivity;
            _requireAuth = requireAuth;

            BackgroundColor = Color.FromHex("efeff4");
        }

        protected async override void OnAppearing()
        {
            if (_requireAuth)
            {
                //Device.BeginInvokeOnMainThread(
                //    () => Application.Current.MainPage = new ExtendedNavigationPage(new HomePage()));
            }

            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            if (_syncIndicator)
            {
                MessagingCenter.Unsubscribe<Application, bool>(Application.Current, "SyncCompleted");
                MessagingCenter.Unsubscribe<Application>(Application.Current, "SyncStarted");
            }

            if (_syncIndicator)
            {
                IsBusy = false;
            }

            base.OnDisappearing();
        }
    }
}
