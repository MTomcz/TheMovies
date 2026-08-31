using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TheMovies.Models
{
    public class Movie : INotifyPropertyChanged
    {
        public string Title { get; set; }
        public int Duration {  get; set; }
        public string Genre {  get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

    }
}
