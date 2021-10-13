using System;
using VideoAppPlayer.Model;

namespace VideoAppPlayer.ViewModel
{
    public class PlayerViewModel : BaseViewModel
    {
        public PlayerViewModel()
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
    }
}
