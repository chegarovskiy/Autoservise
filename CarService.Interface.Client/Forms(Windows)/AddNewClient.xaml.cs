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
using System.Windows.Shapes;
using CarService.Core.Entities;

namespace CarService.Interface.Client.Forms_Windows_
{
    /// <summary>
    /// Interaction logic for AddNewClient.xaml
    /// </summary>
    public partial class AddNewClient : Window
    {
        private Core.Entities.Client _client;
        public AddNewClient()
        {
            InitializeComponent();
        }

        private void BtnAddClient_OnClick(object sender, RoutedEventArgs e)
        {
            //todo make phone as string
            if (IsValid())
            {
                _client = new Core.Entities.Client
                {
                    FullName = tbFullName.Text.Trim(),
                    Phone = tbPhone.Text.Trim(),
                    Address = tbAdress.Text.Trim(),
                    PassportData = tbPassportData.Text.Trim(),
                    Notes = tbNotes.Text.Trim()
                };
                this.DialogResult = true;

                Close();
            }
            else
            {
                MessageBox.Show("Fields \"Full name\" and \"Phone\" can't be empty");
            }
        }

        //todo make validation for client
        private bool IsValid()
        {
            bool result = true;

            if (String.IsNullOrWhiteSpace(tbFullName.Text))
                result= false;

            if (String.IsNullOrWhiteSpace(tbPhone.Text))
                result = false;

            return result;
        }
        public Core.Entities.Client GetClient() => _client;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            tbNotes.Text = "Notes";
        }

        private void tbNotes_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbNotes.Text == "")
            {
                tbNotes.Text = "Notes";
            }
        }

        private void tbNotes_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tbNotes.Text == "Notes")
            {
                tbNotes.Text = "";
            }
        }
    }
}
