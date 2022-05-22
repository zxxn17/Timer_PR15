using System;
using System.IO;
using Timer_PR15.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Timer_PR15
{
    public partial class App : Application
    {
        static ResultsDatabase database;
        public static ResultsDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new ResultsDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Results.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
