using MemoSaver.Services;
using MemoSaver.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using uuUtils;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MemoSaver
{
    public class App : Application
    {
        static ItemDatabase database;

        public App()
        {
            Resources = new ResourceDictionary();
            Resources.Add("primaryGreen", Color.FromHex("91CA47"));
            Resources.Add("primaryDarkGreen", Color.FromHex("6FA22E"));

            if (Cfg.SessionGet("IsLogin", false))
            {
                MainPage = new LoginPage();
            }
            else
            {
                MainPage = new TabMain();
            }
        }

        public static ItemDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new ItemDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ItemSQLite.db3"));
                }
                return database;
            }
        }

        public int ResumeAtTodoId { get; set; }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        //for android
        public bool OnBack()
        {
            return true;
        }
    }
}
