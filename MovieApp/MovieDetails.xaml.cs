namespace MovieApp;

using Microsoft.Maui.Controls;
using MovieDB;
using MovieDB.DB_Tables;
using System.Drawing;
public partial class MovieDetails : ContentPage
{
	private Movie _movie { get; set; }	
	private DBService dbService;
	public MovieDetails(Movie movie)
	{
		InitializeComponent();
		_movie = movie;
		BindingContext = movie;
		dbService = new DBService();
	}
    protected override async void OnAppearing() {
        base.OnAppearing();
        if(_movie.genres.Count > 0) {
            gn1.Text = _movie.genres[0].Name;
           
        }
        var doesFavouriteExist = await this.dbService.CheckIfExists(_movie.Id);
        if(doesFavouriteExist) {
            Add_button.IsVisible = false;
            Remove_button.IsVisible = true;
        } else {
            Add_button.IsVisible = true;
            Remove_button.IsVisible = false;
        }
    }
    private async void On_Favourites_Clicked(object sender, EventArgs e)
    {
        await dbService.AddMovies(_movie);
        OnAppearing(); 
    }
    private async void On_Favourites_Remove(object sender, EventArgs e) 
    {
        await dbService.DeleteMovies(_movie);
        OnAppearing();
    }

    private void Image_Loaded(object sender, EventArgs e) {
        busy.IsVisible = false;
       
    }
}