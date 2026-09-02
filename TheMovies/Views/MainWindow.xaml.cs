using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TheMovies.ViewModels;

namespace TheMovies.Views
{

    public partial class MainWindow : Window
    {
        private MainViewModel viewModel;


        public MainWindow()
        {
            InitializeComponent();

            viewModel = new MainViewModel();


            DataContext = viewModel;

            viewModel.OpenCreateMovie += OpenCreateMovie;
            viewModel.OpenHomePage += OpenHomePage;
            viewModel.OpenMovieListPage += OpenMovieList;
            viewModel.OpenMakeScreening += OpenMakeScreening;
        }

        private void OpenCreateMovie()
        {

            HomePageGrid.Visibility = Visibility.Collapsed;

            MainFrame.Visibility = Visibility.Visible;

            MainFrame.Navigate(new CreateMovie(viewModel));

        }

        private void OpenHomePage()
        {

            MainFrame.Visibility = Visibility.Collapsed;

            HomePageGrid.Visibility = Visibility.Visible;
        }

        private void OpenMovieList()
        {
            HomePageGrid.Visibility = Visibility.Collapsed;

            MainFrame.Visibility = Visibility.Visible;

            MainFrame.Navigate(new MovieList(viewModel));
        }

        private void OpenMakeScreening()
        {

            HomePageGrid.Visibility = Visibility.Collapsed;

            MainFrame.Visibility = Visibility.Visible;

            MainFrame.Navigate(new CreateScreening(viewModel));
        }



    }
}