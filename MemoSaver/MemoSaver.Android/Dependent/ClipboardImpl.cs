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

[assembly: Xamarin.Forms.Dependency(typeof(ClipboardImpl))]
namespace uuUtils.Droid
{
    public class ClipboardImpl : IClipboard
    {
        public void CopyToClipboard(string text)
        {
            var clipboardManager = (ClipboardManager)Forms.Context.GetSystemService(Context.ClipboardService);
            ClipData clip = ClipData.NewPlainText("Android Clipboard", text);
            clipboardManager.PrimaryClip = clip;
        }
    }
}