﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Utilities.wpf.ViewModels;

namespace Utilities.wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            MainWindow window = new MainWindow();

            // Create the ViewModel to which the main window binds.
            var viewModel = new MainWindowViewModel();

            // When the ViewModel asks to be closed, close the window.
            viewModel.RequestClose +=  delegate
            {
                window.Close();
            };

            // All controls in the window to bind to the ViewModel by setting the
            // Datacontext, which propogates down the element tree.
            window.DataContext = viewModel;

            window.Show();

        }

    }
}
