using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;
using TheMovies.Models;

namespace TheMovies.ViewModels
{
    public class MainViewModel
    {
        public Movie Movie { get; set; }
        public ICommand SaveMovieCommand { get; }

        public MainViewModel()
        {
            Movie = new Movie();
        }

        private void SaveMovie()
        {
            MessageBox.Show("Filmen er blevet gemt.");
        }
    }
}
