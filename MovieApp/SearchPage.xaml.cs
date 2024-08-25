using MovieAPI;
using System.ComponentModel;
using MovieDB;
using MovieDB.DB_Tables;
namespace MovieApp {
    public partial class SearchPageViewModel : INotifyPropertyChanged {
        
        
        

        public SearchPageViewModel() {
            InitializeComponent();
            

        }  
        private async void Movie_Selected_handler(object sender, ItemTappedEventArgs e) {
            var tmdbService = new TMDBAPIService();
            var movie = (Movie)e.Item;
            var movieDetailsJSON = await tmdbService.GetMovie(movie.Id);
            MovieDetails movieDetails = new MovieDetails(movieDetailsJSON);
            await Navigation.PushAsync(movieDetails);
        }

        private async void search_bar_TextChanged(object sender, TextChangedEventArgs e) {
            var tmdbService = new TMDBAPIService();
            var movies = await tmdbService.GetMovies(search_bar.Text);
            movie_search.ItemsSource = movies.Results;
            movie_search.BindingContext = movies.Results;
        }
    }

}
