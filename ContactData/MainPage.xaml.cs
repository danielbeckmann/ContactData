using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using ContactData.Resources;
using ContactData.ViewModels;
using Microsoft.Phone.UserData;

namespace ContactData
{
    public partial class MainPage : PhoneApplicationPage
    {
        private MainViewModel viewModel;

        public MainPage()
        {
            InitializeComponent();
            this.viewModel = new MainViewModel();
            this.DataContext = this.viewModel;
        }

        // Daten für die ViewModel-Elemente laden
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            await this.viewModel.LoadDataAsync();
        }
    }
}