using MovieAPI;
using MovieDB;
using MovieDB.DB_Tables;
using System.Collections.Specialized;
using System.ComponentModel;


namespace MovieApp;

public partial class FavouritesViewModel : INotifyPropertyChanged
{
    private DBService db;
    private Movie _movie;
    private bool isLoaded = false;
    public FavouritesViewModel() 
    {
		InitializeComponent();
		db = new DBService();
    }
    protected override async void OnAppearing() {
        base.OnAppearing();
        var movies = await db.GetMovies();
        movie_search.ItemsSource = movies;
        movie_search.BindingContext = movies;

    }
    

    private void Image_Loaded(object sender, EventArgs e) {
        movie_search.IsVisible = true;
        busy.IsVisible = false;
    }

    

    private void movie_search_CurrentItemChanged(object sender, CurrentItemChangedEventArgs e) {
            _movie = e.PreviousItem as Movie;
            db.UpdateMovie(_movie);
    }
}