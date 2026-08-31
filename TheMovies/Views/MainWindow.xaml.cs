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

namespace TheMovies
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new MainViewModel();
        }

        private void GemFilmButton_Click(object sender, RoutedEventArgs e)
        {
            string title = TitleBox.Text;
            string duration = DurationBox.Text;
            string genre = GenreBox.Text;

            MessageBox.Show($"Filmen du har tilføjet er {title} Der varer {duration} minutter i genren {genre}");
        }
    }
}