using MovieAPI;
using MovieDB.DB_Tables;

namespace MovieApp;

public partial class TrendingViewModel : ContentPage
{
    TMDBAPIService tMDBAPI { get; set; }
    private bool IsLoaded { get; set;}
    public TrendingViewModel() {
        InitializeComponent();
        tMDBAPI = new TMDBAPIService();
        IsLoaded = false;
    }
    protected override async void OnAppearing() {
        base.OnAppearing();
        
        if (!IsLoaded) {
            var movies = await tMDBAPI.GetTrendingMovies();
            movie_search.ItemsSource = movies.Results;
            movie_search.BindingContext = movies.Results;
        }
        IsLoaded = true;
    }
    private async void Movie_Selected_handler(object sender, ItemTappedEventArgs e) {
        var movie = e.Item as Movie;
        var movie_detail = await tMDBAPI.GetMovie(movie.Id);
        await Navigation.PushAsync(new MovieDetails(movie_detail));
    }
}