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
using System.Linq;

namespace TheMovies.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {

        //The different json filepaths
        private string filePath = "movies.json";
        private string filmPath = "screenings.json";


        public Movie Movie { get; set; }
        public Screening Screening { get; set; }
        public string ScreeningTime { get; set; }

        public ICommand SaveMovieCommand { get; set; }
        public ICommand CreateScreeningCommand {  get; set; }
        public ICommand CreateMovieCommand { get; set; }
        public ICommand GoBackMovieCommand { get; set; }
        public ICommand MovieListCommand { get; set; }
        public ICommand SaveScreeningCommand { get; set; }
        public  ICommand ScreeningListCommand { get; set; }


        public ObservableCollection<Movie> Movies { get; }
        public ObservableCollection<Screening> Screenings { get; }


        //Asks which of the screenings are in the different cities to make sure they show in the correct movie theater lists
        public IEnumerable<Screening> HjermScreenings => Screenings.Where(s  => s.MovieTheater == "Hjerm");
        public IEnumerable<Screening> VidebækScreenings => Screenings.Where(s => s.MovieTheater == "Videbæk");
        public IEnumerable<Screening> ThorsmindeScreenings => Screenings.Where(s => s.MovieTheater == "Thorsminde");
        public IEnumerable<Screening> RæhrScreenings => Screenings.Where(s => s.MovieTheater == "Ræhr");




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
            ScreeningListCommand = new RelayCommand(OpenScreeningList);


            LoadMovies();
            LoadScreenings();



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

        public void LoadScreenings()
        {
            if (File.Exists(filmPath))
            {
                string json = File.ReadAllText(filmPath);

                List<Screening> screenings = JsonSerializer.Deserialize<List<Screening>>(json);

                if (screenings != null)
                {
                    foreach (Screening screening in screenings)
                    {
                        Screenings.Add(screening);
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

        private void SaveScreening()
        {
            if (DateTime.TryParse(ScreeningTime, out DateTime time))
            {
                Screening.Showtime = Screening.Showtime.Date + time.TimeOfDay;

                Screenings.Add(Screening);

                string json = JsonSerializer.Serialize(Screenings, new JsonSerializerOptions { WriteIndented = true });

                File.WriteAllText(filmPath, json);

                MessageBox.Show("Screening er blevet gemt.");

            }
            else
            {
                MessageBox.Show("Skriv venligst et rigtigt tidspunkt, som eksempel 13:30");
            }
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

        private void OpenScreeningList()
        {
            OpenScreeningPage.Invoke();
        }




        public event PropertyChangedEventHandler? PropertyChanged;
        public event Action OpenCreateMovie;
        public event Action OpenHomePage;
        public event Action OpenMovieListPage;
        public event Action OpenMakeScreening;
        public event Action OpenScreeningPage;

        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


    }
}
