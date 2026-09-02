using System;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Input;
using TheMovies.Commands;
using TheMovies.Models;
using System.Text.Json;
using System.Runtime.CompilerServices;
using System.IO;
using System.ComponentModel;
using TheMovies.Views;
using System.Security.Cryptography.X509Certificates;

namespace TheMovies.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string filePath = "movies.json";


        public Movie Movie { get; set; }
        public Screening Screening { get; set; }
        public string ScreeningTime { get; set; }

        public ICommand SaveMovieCommand { get; set; }
        public ICommand CreateScreeningCommand {  get; set; }
        public ICommand CreateMovieCommand { get; set; }
        public ICommand GoBackMovieCommand { get; set; }
        public ICommand MovieListCommand { get; set; }
        public ICommand SaveScreeningCommand { get; set; }


        public ObservableCollection<Movie> Movies { get; }
        public ObservableCollection<Screening> Screenings { get; }


        public MainViewModel()
        {

            Movie = new Movie();
            Screening = new Screening();
            ScreeningTime = "";

            Movies = new ObservableCollection<Movie>();
            Screenings = new ObservableCollection<Screening>();


            SaveMovieCommand = new RelayCommand(SaveMovie);
            CreateScreeningCommand = new RelayCommand(MakeScreening);
            CreateMovieCommand = new RelayCommand(MakeMovie);
            GoBackMovieCommand = new RelayCommand(MovieGoBack);
            MovieListCommand = new RelayCommand(OpenMovieList);
            SaveScreeningCommand = new RelayCommand(SaveScreening);


            LoadMovies();



        }

        public void LoadMovies()
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);

                List<Movie> movies = JsonSerializer.Deserialize<List<Movie>>(json);

                if (movies != null)
                {
                    foreach (Movie movie in movies)
                    {
                        Movies.Add(movie);
                    }
                }

            }
        }

        private void SaveMovie()
        {
            Movies.Add(Movie);

            string json = JsonSerializer.Serialize(Movies, new JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText(filePath, json);

            MessageBox.Show("filmen er blevet gemt.");


        }

        public void MakeScreening()
        {
            OpenMakeScreening.Invoke();

        }

        private void MakeMovie()
        {
            OpenCreateMovie.Invoke();

        }

        private void MovieGoBack()
        {
            OpenHomePage.Invoke();
        }

        private void OpenMovieList()
        {
            OpenMovieListPage.Invoke();

        }

        private void SaveScreening()
        {
            if (DateTime.TryParse(ScreeningTime, out DateTime time))
            {
                Screening.Showtime = Screening.Showtime.Date + time.TimeOfDay;

                Screenings.Add(Screening);

                MessageBox.Show("Screening er blevet gemt.");

            }
            else
            {
                MessageBox.Show("Skriv venligst et rigtigt tidspunkt, som eksempel 13:30");
            }
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        public event Action OpenCreateMovie;
        public event Action OpenHomePage;
        public event Action OpenMovieListPage;
        public event Action OpenMakeScreening;

        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


    }
}
