using Microsoft.VisualBasic;
using MovieDB.DB_Tables;
using SQLite;
using System.Security.AccessControl;
using System.Text;
namespace MovieDB {
    public class DBService {
        public const string DB_NAME = "MovieDB.db3";
        public SQLiteAsyncConnection connection { get; set; }
        public DBService() {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DB_NAME);
            this.connection = new SQLiteAsyncConnection(dbPath);
            this.connection.CreateTableAsync<Movie>();
           
        }
        public async Task<List<Movie>?> GetMovies() {
            try {
                var list = await connection.Table<Movie>().ToListAsync();
            return list;
            } catch (System.Exception ex) {
                return null;
            }
}
        public async Task<bool> UpdateMovie(Movie movie) {
            try {
                var list = await connection.UpdateAsync(movie);
                return true;
            } catch (System.Exception ex) {
                return false;
            }
        }
        public async Task<bool> AddMovies(Movie city) {
            try {
                await connection.InsertAsync(city);
                return true;
            } catch (System.Exception ex) {
                return false;
            }
        }
        public async Task<bool> CheckIfExists(int id) {
            var doesExist = await connection.Table<Movie>().Where(x=>x.Id == id).ToListAsync();
            if(doesExist.Count > 0) {
                return true;
            } else {
                return false;
            }
        }
        public async Task<bool> DeleteMovies(Movie city) {
            try {
                await connection.DeleteAsync(city);
                return true;
            } catch (System.Exception ex) {
                return false;
            }
        }
    }
}
