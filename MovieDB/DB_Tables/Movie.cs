using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using static System.Net.WebRequestMethods;
namespace MovieDB.DB_Tables {

    
    public class Movie {
        [PrimaryKey]
        public int Id { get; set; }

        private string poster_path;
        private string backdrop_path;   
        public string Original_Language { get; set; }

        public string Original_Title { get; set; }
        public string Overview { get; set; }    
        public float Popularity { get; set; }  
        public string Poster_Path {
            get { return poster_path; }
            set { poster_path = $"https://image.tmdb.org/t/p/original{value}"; }
        }
        public string Backdrop_Path {
            get { return backdrop_path; }
            set { backdrop_path = $"https://image.tmdb.org/t/p/original{value}"; }
        }

        public decimal Vote_Average { get; set; }
        public decimal Vote_Count { get; set; }
        public string Release_Date { get; set; }
        public string Tagline { get; set; }
        public int Budget { get; set; } 
        public int Revenue { get; set; }
        public double Rating { get; set; }
        public int Runtime { get; set; }
        [Ignore]
        public List<Genre> genres { get; set; }
    }
}
