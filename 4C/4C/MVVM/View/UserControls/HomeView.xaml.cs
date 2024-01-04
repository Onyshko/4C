using _4C.MVVM.ViewModel;
using System.Windows.Controls;
using static System.Net.Mime.MediaTypeNames;

namespace _4C.MVVM.View.UserControls
{
    public partial class HomeView : UserControl
    {
        public HomeView()
        {
            InitializeComponent();
            var homeViewModel = new HomeViewModel(ctbSearch.Text);
            DataContext = homeViewModel;
        }

        private void Search_Button(object sender, System.Windows.RoutedEventArgs e)
        {
            var homeViewModel = new HomeViewModel(ctbSearch.Text);
            DataContext = homeViewModel;
        }
    }
}
