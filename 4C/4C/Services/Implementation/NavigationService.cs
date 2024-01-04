using _4C.MVVM.View.UserControls;
using _4C.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace _4C.Services.Implementation
{
    public class NavigationService : INavigationService
    {
        private Frame _mainContentFrame;

        public NavigationService(Frame mainContentFrame)
        {
            _mainContentFrame = mainContentFrame;
        }

        public void NavigateTo(string viewName)
        {
            switch (viewName)
            {
                case "HomeView":
                    _mainContentFrame.Content = new HomeView();
                    break;
                case "ExchangesView":
                    _mainContentFrame.Content = new ExchangesView();
                    break;
                default:
                    break;
            }
        }
    }


}
