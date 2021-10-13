using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Windows.Input;
using Newtonsoft.Json;
using VideoAppPlayer.Model;
using VideoAppPlayer.View;
using Xamarin.Forms;

namespace VideoAppPlayer.ViewModel
{
    public class MovieListViewModel : BaseViewModel
    {
        public MovieListViewModel()
        {
            GetOnlineData();
        }

        public Movie FeaturedMovie => WatchList?.Where(x => x.IsFeatured == true).FirstOrDefault();


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

        private ObservableCollection<Movie> watchList;
        public ObservableCollection<Movie> WatchList
        {
            get { return watchList; }
            set
            {
                watchList = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(FeaturedMovie));
            }
        }

        public ICommand SelectionCommand => new Command(() =>
        {
        if (selectedMovie != null)
        {
                var vm = new DetailViewModel { SelectedMovie = selectedMovie };
                var page = new DetailPage { BindingContext = vm };
                Application.Current.MainPage.Navigation.PushAsync(page);
            }
        });

        public ICommand PlayCommand => new Command(() =>
        {
            if (FeaturedMovie != null)
            {
                var vm = new PlayerViewModel { SelectedMovie = FeaturedMovie };
                var page = new PlayerPage { BindingContext = vm };
                Application.Current.MainPage.Navigation.PushAsync(page);
            }
        });

        private async void GetOnlineData()
        {
            var client = new HttpClient();
            var result = await client.GetStringAsync("https://devcrux.com/movies.json");
            WatchList = JsonConvert.DeserializeObject<ObservableCollection<Movie>>(result);
        }
    }
}
