using System;
using System.Windows.Input;
using VideoAppPlayer.Model;
using VideoAppPlayer.View;
using Xamarin.Forms;

namespace VideoAppPlayer.ViewModel
{
    public class DetailViewModel : BaseViewModel
    {
        public DetailViewModel()
        {
        }

        private Movie selectedMovie;

        public Movie SelectedMovie
        {
            get { return selectedMovie; }

            set
            {
                selectedMovie = value;

                OnPropertyChanged();
            }
        }

        public ICommand PlayCommand => new Command(() =>{

            var vm = new PlayerViewModel { SelectedMovie = selectedMovie };

            var page = new PlayerPage { BindingContext = vm };
            Application.Current.MainPage.Navigation.PushAsync(page);

        });
    }
}
