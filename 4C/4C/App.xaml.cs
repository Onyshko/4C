﻿using _4C.MVVM.ViewModel;
using _4C.Services.Implementation;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace _4C
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var mainWindow = new MainWindow();
            var navigationService = new NavigationService(mainWindow.MainFrame);
            var navigationBarViewModel = new NavigationBarViewModel(navigationService);
            mainWindow.DataContext = navigationBarViewModel;
            mainWindow.Show();
        }
    }

}
