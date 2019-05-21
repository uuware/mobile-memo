using System;
using System.Collections.Generic;
using System.Linq;

using Xamarin.Forms;
using uuUtils;
using System.IO;
using Android.Content.Res;
using uuUtils.Droid;

[assembly: Dependency(typeof(FileUtilsImpl))]
namespace uuUtils.Droid
{
    public class FileUtilsImpl : IFileUtils
    {
        static public AssetManager assets;
        public bool FWrite(string filename, string text)
        {
            try
            {
                var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                var filePath = Path.Combine(documentsPath, filename);
                System.IO.File.WriteAllText(filePath, text);
                return true;
            }
            catch (Exception e)
            {
                Log.Debug(e.ToString());
            }
            return false;
        }
        public string FRead(string filename)
        {
            try
            {
                var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                var filePath = Path.Combine(documentsPath, filename);
                if (!System.IO.File.Exists(filePath))
                {
                    return null;
                }
                return System.IO.File.ReadAllText(filePath);
            }
            catch (Exception e)
            {
                Log.Debug(e.ToString());
            }
            return null;
        }
        public bool FRemove(string filename)
        {
            try
            {
                var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                var filePath = System.IO.Path.Combine(documentsPath, filename);
                if (!System.IO.File.Exists(filePath))
                {
                    return false;
                }
                System.IO.File.Delete(filePath);
                return (System.IO.File.Exists(filePath)) ? false : true;
            }
            catch (Exception e)
            {
                Log.Debug(e.ToString());
            }
            return false;
        }
        public bool DCreate(string filepath)
        {
            try
            {
                var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                var filePath = System.IO.Path.Combine(documentsPath, filepath);
                if (!System.IO.Directory.Exists(filePath))
                {
                    System.IO.Directory.CreateDirectory(filePath);
                }
                return (System.IO.Directory.Exists(filePath)) ? true : false;
            }
            catch (Exception e)
            {
                Log.Debug(e.ToString());
            }
            return false;
        }
        public bool DRemove(string filepath)
        {
            try
            {
                var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                var filePath = System.IO.Path.Combine(documentsPath, filepath);
                if (System.IO.Directory.Exists(filePath))
                {
                    System.IO.Directory.Delete(filePath);
                }
                return (System.IO.Directory.Exists(filePath)) ? false : true;
            }
            catch (Exception e)
            {
                Log.Debug(e.ToString());
            }
            return false;
        }

        public string[] GetFiles(string filepath)
        {
            try
            {
                var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                var filePath = System.IO.Path.Combine(documentsPath, filepath);
                if (!Directory.Exists(filePath))
                {
                    return null;
                }
                return Directory.GetFiles(filePath);
            }
            catch (Exception e)
            {
                Log.Debug(e.ToString());
            }
            return null;
        }

        /// <summary>
        /// GetDocumentPath 
        /// </summary>
        /// <returns></returns>
        public string GetDocumentPath()
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            //string path = DependSerivce.GetDocumentPath();
            //if (String.IsNullOrEmpty(path))
            //{
            //    path = DependSerivce.GetDownloadPath();
            //}
            return path;
        }
        public string LoadAssertFile(string filename)
        {
            try
            {
                using (StreamReader sr = new StreamReader(assets.Open(filename)))
                {
                    string sTxt = sr.ReadToEnd();
                    return sTxt;
                }
            }
            catch (Exception e)
            {
                Log.Debug(e.ToString());
            }
            return null;
        }
        static public bool IsSdcardReadable()
        {
            var sdCardState = Android.OS.Environment.ExternalStorageState;
            switch (sdCardState)
            {
                case Android.OS.Environment.MediaMounted:
                    return true;
                case Android.OS.Environment.MediaMountedReadOnly:
                    return true;
                case Android.OS.Environment.MediaRemoved:
                    break;
                case Android.OS.Environment.MediaUnmounted:
                    break;
                default:
                    break;
            }
            return false;
        }
        static public bool IsSdcardMounted()
        {
            var sdCardState = Android.OS.Environment.ExternalStorageState;
            switch (sdCardState)
            {
                case Android.OS.Environment.MediaMounted:
                    return true;
                case Android.OS.Environment.MediaMountedReadOnly:
                    break;
                case Android.OS.Environment.MediaRemoved:
                    break;
                case Android.OS.Environment.MediaUnmounted:
                    break;
                default:
                    break;
            }
            return false;
        }
    }
}

