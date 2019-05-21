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

[assembly: Dependency(typeof(DependDeviceImpl))]
namespace uuUtils.Droid
{
    public class DependDeviceImpl : IDependDevice
    {
        static public MainActivity curentActivity;
        public string GetPackageName()
        {
            Context context = Forms.Context;
            var name = context.PackageManager.GetPackageInfo(context.PackageName, 0).PackageName;
            return name;
        }
        public string GetDocumentPath()
        {
            try
            {
                var dir = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDocuments);
                return dir.AbsolutePath;
            }
            catch
            {
                return String.Empty;
            }
        }
        public string GetDownloadPath()
        {
            try
            {
                var dir = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDownloads);
                return dir.AbsolutePath;
            }
            catch
            {
                return String.Empty;
            }
        }
        public void OutPutLog(string path, string err)
        {
            System.IO.FileStream fs = new FileStream(path, FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(err);
            sw.Close();
            fs.Close();
            sw = null;
            fs = null;
        }
        public void KeepScreenOn(bool isKeep)
        {
            System.Diagnostics.Debug.Assert(curentActivity != null);
            curentActivity.KeepScreenOn(isKeep);
        }
    }
}