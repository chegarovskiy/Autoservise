using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CarService.Service.CarWcfServer;
using UserControl = System.Windows.Controls.UserControl;
using CarService.Core.Entities;

namespace CarService.Interface.Client.Forms_Windows_.UserControls
{
    /// <summary>
    /// Interaction logic for UcWarehouse.xaml
    /// </summary>
    public partial class UcWarehouse : UserControl
    {
        private readonly CarAppService _client = new CarAppService();
        private readonly List<SpareTwin> _bindList = new List<SpareTwin>();

        public UcWarehouse()
        {
            InitializeComponent();
            //_client.GetSpares().ToList();
            ShowSparesInListView(_client.GetSpares());
        }

        private void BtnAddSpares_OnClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog importSpares = new OpenFileDialog();
            importSpares.ShowDialog();
        }

        private void BtnSearch_OnClick(object sender, RoutedEventArgs e)
        {
            lvSpares.ItemsSource = _bindList.Where(x => x.Code.Contains(tbSearchByCode.Text.Trim()));
        }

        private void ShowSparesInListView(IEnumerable<Spare> spares)
        {  
            if(spares == null)
                return;        
            foreach (var spare in spares)
            {
                //double totalPrice = spare.MarkupPercentage*spare.Price/100;
                _bindList.Add(new SpareTwin
                {
                    Code = spare.Code,
                    Manufacturer = spare.Manufacturer.Name,
                    Name = spare.Name,
                    MarkupPercentage = spare.MarkupPercentage,
                    Quantity = spare.Quantity,
                    Price = spare.Price,
                    TotalPrice = spare.MarkupPercentage*spare.Price/100 + spare.Price,
                    Description = spare.Description
                });
            }
            //lvSpares.ItemsSource = bindList;
            lvSpares.ItemsSource = _bindList;

        }

        private void LvSpares_OnPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var currentSpare = ((System.Windows.Controls.ListView) sender).SelectedItem;
            if(currentSpare != null)
                tbDescription.Text = ((SpareTwin) currentSpare).Description;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            tbSearchByCode.Text = "Code of spare";
        }

        private void tbSearchByCode_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbSearchByCode.Text == "")
            {
                tbSearchByCode.Text = "Code of spare";
            }
        }

        private void tbSearchByCode_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tbSearchByCode.Text == "Code of spare")
            {
                tbSearchByCode.Text = "";
            }
        }
    }
}
