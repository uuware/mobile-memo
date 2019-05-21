using System;
using System.IO;
using Foundation;
using Xamarin.Forms;

[assembly: Dependency(typeof(uuUtils.iOS.DependDeviceImpl))]
namespace uuUtils.iOS
{
    public class DependDeviceImpl : IDependDevice
    {
        public string GetPackageName()
        {
            string name = NSBundle.MainBundle.InfoDictionary["CFBundleDisplayName"].ToString();
            return name.ToString();
        }
        public string GetDocumentPath()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }
        public string GetDownloadPath()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.InternetCache);
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
            throw new NotImplementedException();
        }
    }
}