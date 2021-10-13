using System;
using VideoAppPlayer.View;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VideoAppPlayer
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new WatchListPage());
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
