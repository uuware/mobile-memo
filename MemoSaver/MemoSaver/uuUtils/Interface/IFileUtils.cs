using System;
using System.Diagnostics;

namespace uuUtils
{
    public interface IFileUtils
    {
        //DependencyService.Get<ISaveAndLoad>().SaveText("temp.txt", input.Text);
        bool FWrite(string filename, string text);
        //Text = DependencyService.Get<ISaveAndLoad>().LoadText("temp.txt");
        string FRead(string filename);
        bool FRemove(string filename);
        bool DCreate(string filepath);
        bool DRemove(string filepath);
        string GetDocumentPath();
        string[] GetFiles(string filepath);
        string LoadAssertFile(string filename);
    }
}

