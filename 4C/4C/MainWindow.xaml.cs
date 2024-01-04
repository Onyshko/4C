using _4C.MVVM.ViewModel;
using _4C.Services.Implementation;
using System.Windows;
using System.Windows.Controls;

namespace _4C
{
    public partial class MainWindow : Window
    {
        public Frame MainFrame { get { return this.MainContentFrame; } }

        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
