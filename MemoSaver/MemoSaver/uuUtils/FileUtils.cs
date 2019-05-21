using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uuUtils;
using Xamarin.Forms;

namespace uuUtils
{
    public class FileUtils
    {
        static IFileUtils saveAndLoad = DependencyService.Get<IFileUtils>();
        public static bool FWrite(string filename, string text)
        {
            return saveAndLoad.FWrite(filename, text);
        }
        public static string FRead(string filename)
        {
            return saveAndLoad.FRead(filename);
        }
        public static bool FRemove(string filename)
        {
            return saveAndLoad.FRemove(filename);
        }
        public static bool DCreate(string filepath)
        {
            return saveAndLoad.DCreate(filepath);
        }
        public static bool DRemove(string filepath)
        {
            return saveAndLoad.DRemove(filepath);
        }
        public static string GetDocumentPath()
        {
            return saveAndLoad.GetDocumentPath();
        }
        public static string[] GetFiles(string filepath)
        {
            return saveAndLoad.GetFiles(filepath);
        }
        public static string LoadAssertFile(string filename)
        {
            return saveAndLoad.LoadAssertFile(filename);
        }
    }
}
