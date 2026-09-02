using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TheMovies.Models
{
    public class Movie : INotifyPropertyChanged
    {
        private string _title;
        private int _duration;
        private string _genre;

        private string _director;
        private DateOnly _premierdate;

        public event PropertyChangedEventHandler? PropertyChanged;

        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Title)));
            }
        }

        public int Duration
        {
            get
            {
                return _duration;
            }
            set
            {
                _duration = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Duration)));
            }
        }

        public string Genre
        {
            get
            {
                return _genre;
            }

            set
            {
                _genre = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Genre)));
            }
        }

        public string Director
        {
            get
            {
                return _director;
            }
            set
            {
                _director = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Director)));
            }
        }

        public DateOnly Premierdate
        {
            get
            {
                return _premierdate;
            }
            set
            {
                _premierdate = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Premierdate)));
            }
        }

    }
}
