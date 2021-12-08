using DevProg_EindOpdracht.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DevProg_EindOpdracht
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
            NavigationPage OwnedPage = new NavigationPage(new OwnedPage());
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
