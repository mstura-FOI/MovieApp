using RestSharp;
using MovieDB.DB_Tables;
using System.Text.Json;
namespace MovieAPI {
    public class TMDBAPIService {
        public const string API_KEY = "";
        public RestResponse? response { get; set; }

        public TMDBAPIService() {
            
        }

        public async Task<Movies?> GetMovies(string movie_name) {
            var options = new RestClientOptions($"https://api.themoviedb.org/3/search/movie?query={movie_name}&include_adult=false&language=en-US&page=1");
            var client = new RestClient(options);
            var request = new RestRequest("");
            request.AddHeader("accept", "application/json");
            request.AddHeader("Authorization", $"Bearer {API_KEY}");
            response = await client.GetAsync(request);
            if (response.IsSuccessStatusCode) {
                string content =  response.Content;
                var movies = JsonSerializer.Deserialize<Movies>(content, new JsonSerializerOptions {
                    WriteIndented = true,
                    PropertyNameCaseInsensitive = true
                });
                return movies;
            }
            return null;
        }
        public async Task<Movies?> GetTrendingMovies() {
            var options = new RestClientOptions($"https://api.themoviedb.org/3/movie/popular?language=en-US&page=1");
            var client = new RestClient(options);
            var request = new RestRequest("");
            request.AddHeader("accept", "application/json");
            request.AddHeader("Authorization", $"Bearer {API_KEY}");
            this.response = await client.GetAsync(request);
            if (response.IsSuccessStatusCode) {
                string content = response.Content;
                var movies = JsonSerializer.Deserialize<Movies>(content, new JsonSerializerOptions {
                    WriteIndented = true,
                    PropertyNameCaseInsensitive = true
                });
                return movies;
            }
            return null;
        }
        public async Task<Movies?> GetTopRatedMovies() {
            var options = new RestClientOptions($"https://api.themoviedb.org/3/movie/top_rated?language=en-US&page=1");
            var client = new RestClient(options);
            var request = new RestRequest("");
            request.AddHeader("accept", "application/json");
            request.AddHeader("Authorization", $"Bearer {API_KEY}");
            this.response = await client.GetAsync(request);
            if (response.IsSuccessStatusCode) {
                string content = response.Content;
                var movies = JsonSerializer.Deserialize<Movies>(content, new JsonSerializerOptions {
                    WriteIndented = true,
                    PropertyNameCaseInsensitive = true
                });
                return movies;
            }
            return null;
        }
        public async Task<Movie?> GetMovie(int id) {
        var options = new RestClientOptions($"https://api.themoviedb.org/3/movie/{id}&language=en-US");
        var client = new RestClient(options);
        var request = new RestRequest("");
        request.AddHeader("accept", "application/json");
            request.AddHeader("Authorization", $"Bearer {API_KEY}");
            var response = await client.GetAsync(request);
        if (response.IsSuccessStatusCode) {
            string content = response.Content;
            var movie = JsonSerializer.Deserialize<Movie>(content, new JsonSerializerOptions {
                WriteIndented = true,
                PropertyNameCaseInsensitive = true
            });
            return movie;
        }
        return null;
    }
    }
    
}
