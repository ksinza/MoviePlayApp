using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace VideoAppPlayer.View
{
    public partial class WatchListPage : ContentPage
    {
        public WatchListPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            moviesColView.SelectedItem = null;
        }
    }
}
