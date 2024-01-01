using _4C.ViewModel;
using System.Windows;

namespace _4C
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            Loaded += async (sender, e) => await mainWindowViewModel.InitializeAsync();
            DataContext = mainWindowViewModel;
        }
    }
}
