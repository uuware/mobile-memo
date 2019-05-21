using System;
using System.Collections.Generic;
using System.Linq;

using Xamarin.Forms;
using System.IO;

[assembly: Dependency(typeof(uuUtils.iOS.FileUtilsImpl))]
namespace uuUtils.iOS
{
    public class FileUtilsImpl : IFileUtils
    {
        //public static IDependSerivce DependSerivce = DependencyService.Get<IDependSerivce>();

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
                System.IO.File.Delete(filePath);
                return (System.IO.File.Exists(filePath)) ? false : true;
            }
            catch (Exception e)
            {
                Log.Debug(e.ToString());
            }
            return false;
        }

        /// <summary>
        /// ドキュメントディレクトリを取得する
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

        public string[] GetFiles(string filepath)
        {
            throw new NotImplementedException();
        }
        public string LoadAssertFile(string filename)
        {
            throw new NotImplementedException();
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
    }
}

