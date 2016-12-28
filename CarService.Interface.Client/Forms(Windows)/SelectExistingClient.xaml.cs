using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CarService.Service.CarWcfServer;

namespace CarService.Interface.Client.Forms_Windows_
{
    /// <summary>
    /// Interaction logic for SelectExistingClient.xaml
    /// </summary>
    public partial class SelectExistingClient : Window
    {
        private readonly CarAppService _client;
        private List<Core.Entities.Client> _clients;
        private Core.Entities.Client _concreteClient;
        public SelectExistingClient(CarAppService client)
        {
            InitializeComponent();
            _client = client;
            DrowListView();
        }

        private void DrowListView()
        {
            //_client.
            lvClients.ItemsSource = _clients;
        }
        
        private void BtnSearch_OnClick(object sender, RoutedEventArgs e)
        {
            lvClients.ItemsSource = _clients.Where(x => x.FullName.Contains(tbSearchByCode.Text.Trim()));

        }

        private void LvClients_OnPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            _concreteClient = (Core.Entities.Client) ((System.Windows.Controls.ListView) sender).SelectedItem;
            if (_concreteClient != null)
            {
                btnSelect.IsEnabled = true;
            }
        }
        private void BtnSelect_OnClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            Close();
        }

        public Core.Entities.Client GetClient() => _concreteClient;

        private void tbSearchByCode_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tbSearchByCode.Text == "Full name...")
            {
                tbSearchByCode.Text = "";
            }
        }

        private void tbSearchByCode_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbSearchByCode.Text == "")
            {
                tbSearchByCode.Text = "Full name...";
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            tbSearchByCode.Text = "Full name...";
        }
    }
}
