using Android.Content;
using Android.Graphics;
using Android.Util;
using Android.Views;
using Android.Widget;
using MemoSaver.Droid;
using System;
using System.IO;
using uuUtils;
using uuUtils.Droid;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(ToastImpl))]
namespace uuUtils.Droid
{
    public class ToastImpl : IToast
    {
        public void Show(string message)
        {
            Android.Widget.Toast.MakeText(Android.App.Application.Context, message, ToastLength.Long).Show();
        }
    }
}