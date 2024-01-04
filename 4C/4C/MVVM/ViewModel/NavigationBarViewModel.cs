using _4C.Services.Interfaces;
using System.Windows.Input;

namespace _4C.MVVM.ViewModel
{
    public class NavigationBarViewModel
    {
        private INavigationService _navigationService;
        public ICommand NavigateHomeCommand { get; }
        public ICommand NavigateExchangesCommand { get; }

        public NavigationBarViewModel(INavigationService navigationService)
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
