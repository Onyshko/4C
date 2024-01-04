using _4C.Model;
using _4C.MVVM;
using _4C.MVVM.View;
using _4C.Services.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace _4C.MVVM.ViewModel
{
    class MainWindowViewModel : ViewModelBase
    {
        private INavigationService _navigationService;
        public ICommand NavigateHomeCommand { get; }
        public ICommand NavigateExchangesCommand { get; }
        

        public MainWindowViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            NavigateHomeCommand = new RelayCommand(param => NavigateHome());
            NavigateExchangesCommand = new RelayCommand(param => NavigateExchanges());

            NavigateHome();
        }

        private void NavigateHome()
        {
            _navigationService.NavigateTo("HomeView");
        }

        private void NavigateExchanges()
        {
            _navigationService.NavigateTo("ExchangesView");
        }
    }
}
