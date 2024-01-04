using _4C.MVVM.ViewModel;
using System.Windows.Controls;

namespace _4C.MVVM.View.UserControls
{
    public partial class HomeView : UserControl
    {
        public HomeView()
        {
            InitializeComponent();
            var homeViewModel = new HomeViewModel();
            Loaded += async (sender, e) => await homeViewModel.InitializeAsync();
            DataContext = homeViewModel;
        }
    }
}
