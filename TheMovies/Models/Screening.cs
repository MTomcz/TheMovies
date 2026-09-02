using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace TheMovies.Models
{
    public class Screening : INotifyPropertyChanged
    {

        private Movie _movie;
        private DateTime _showtime;
        private string _movietheater;


        public event PropertyChangedEventHandler? PropertyChanged;

        public Movie Movie
        {
            get
            {
                return _movie;
            }
            set
            {
                _movie = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Movie)));
            }
        }

        public DateTime Showtime
        {
            get
            {
                return _showtime;
            }
            set
            {
                _showtime = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Showtime)));
            }
        }

        public string MovieTheater
        {
            get
            {
                return _movietheater;
            }
            set
            {
                _movietheater = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MovieTheater)));
            }
        }



    }
}
