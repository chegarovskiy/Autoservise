using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using CarService.Service.CarWcfServer;

namespace CarService.Interface.Client.Forms_Windows_.UserControls
{
    /// <summary>
    /// Interaction logic for UcMakeOrder.xaml
    /// </summary>
    public partial class UcMakeOrder : UserControl
    {
        private readonly CarAppService _clientServices =  new CarAppService();
        public UcMakeOrder()
        {
            InitializeComponent();
        }

        //Open window with list on it
        private void ChooseExistingClient_OnClick(object sender, RoutedEventArgs e)
        {
            var searchClient = new SelectExistingClient(_clientServices);
            if (searchClient.DialogResult == true)
            {
                tbClient.Text = searchClient.GetClient().FullName;
            }
        }

        //Create client window
        private void NewClient_OnClick(object sender, RoutedEventArgs e)
        {
            AddNewClient newClient = new AddNewClient();
            if (newClient.ShowDialog() == true)
            {
                tbClient.Text = newClient.GetClient().FullName;
            }
        }

        private void RemoveSelectedRow_OnPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //throw new NotImplementedException();
        }

        //window with list of workers
        private void MenuWorker_OnPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //throw new NotImplementedException();
        }
    }
}
