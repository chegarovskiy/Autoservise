using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Validation;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CarService.Core.BusinessLogicLayer;
using CarService.Core.BusinessLogicLayer.Implementations;
using CarService.Core.DataAccessLayer;
using CarService.Core.DataAccessLayer.Context;
using CarService.Core.DataAccessLayer.Repositories;
using CarService.Core.DataAccessLayer.Repositories.Implementations;
using CarService.Core.Entities;
using CarService.Interface.Client.Forms_Windows_.UserControls;

using CarService.Service.CarWcfServer;
using ProgressBar = CarService.Interface.Client.Helpers.ProgressBar;

namespace CarService.Interface.Client.Forms_Windows_
{
    /// <summary>
    /// Interaction logic for UserMainWindow.xaml
    /// </summary>
    public partial class UserMainWindow : Window
    {
        public UserMainWindow()
        {
            InitializeComponent();
            GridForUserControls.Children.Add(new UcCalendar());
        }

        private void BtnCalendar_OnClick(object sender, RoutedEventArgs e)
        {
            Title = "Calendar";
            GridForUserControls.Children.Clear();
            GridForUserControls.Children.Add(new UcCalendar());
            
        }

        private void BtnWarehouse_OnClick(object sender, RoutedEventArgs e)
        {
            Title = "Warehouse";
            GridForUserControls.Children.Clear();
            GridForUserControls.Children.Add(new UcWarehouse());
        }

        private void BtnNewOrder_OnClick(object sender, RoutedEventArgs e)
        {
            Title = "New order";
            GridForUserControls.Children.Clear();
            GridForUserControls.Children.Add(new UcMakeOrder());
        }
        private void btnReport_Click(object sender, RoutedEventArgs e)
        {
            Title = "Report";
            GridForUserControls.Children.Clear();
            GridForUserControls.Children.Add(new UcReport());
        }

        private void BtnAbout_OnClick(object sender, RoutedEventArgs e)
        {
            var aboutWindow = new AboutCarServiceApp();
            aboutWindow.ShowDialog();
        }
    }
}
