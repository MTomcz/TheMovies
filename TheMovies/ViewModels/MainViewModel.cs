using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;
using TheMovies.Commands;
using TheMovies.Models;
using System.Text.Json;
using System.Runtime.CompilerServices;
using System.IO;
using System.ComponentModel;

namespace TheMovies.ViewModels
{
    public class MainViewModel
    {
        private string filePath = "movies.json";


        public Movie Movie { get; set; }
        public ICommand SaveMovieCommand { get; set; }
        public List<Movie> Movies { get; set; }



        public MainViewModel()
        {
            Movie = new Movie();

            Movies = new List<Movie>();

            SaveMovieCommand = new RelayCommand(SaveMovie);

            LoadMovies();

        }

        public void LoadMovies()
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                Movies = JsonSerializer.Deserialize<List<Movie>>(json);
            }
        }

        private void SaveMovie()
        {
            Movies.Add(Movie);

            string json = JsonSerializer.Serialize(Movies, new JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText(filePath, json);

            MessageBox.Show("filmen er blevet gemt.");


        }


    }
}
