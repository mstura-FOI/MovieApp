using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
namespace MovieDB.DB_Tables {
    public partial class Movies : ObservableObject {
        [ObservableProperty]
        public ObservableCollection<Movie> results = new();
    }
}
