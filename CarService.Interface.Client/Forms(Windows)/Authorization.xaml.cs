using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using ProgressBar = CarService.Interface.Client.WindowsWpf.ProgressBar;

namespace CarService.Interface.Client.WindowsWpf
{
    /// <summary>
    /// Interaction logic for Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        public Authorization()
        {
            InitializeComponent();
            TbPassword.Visibility = Visibility.Hidden;
        }

        private void ImgShowHidePassword_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (TbPassword.Visibility == Visibility.Visible)
            {
                ImgShowHidePassword.BeginInit();
                ImgShowHidePassword.Source = new BitmapImage(new Uri("/Resources/img/Eye-icon-closed.png", UriKind.Relative));
                ImgShowHidePassword.EndInit();

                TbPassword.Visibility = Visibility.Hidden;
                PasswordBox.Password = TbPassword.Text;
                 
            }
            else
            {
                ImgShowHidePassword.BeginInit();
                ImgShowHidePassword.Source = new BitmapImage(new Uri("/Resources/img/Eye-icon-open.png", UriKind.Relative));
                ImgShowHidePassword.EndInit();

                TbPassword.Visibility = Visibility.Visible;
                TbPassword.Text = PasswordBox.Password;

            }
        }

        private void BtnSignIn_OnMouseLeftButtonUp(object sender, RoutedEventArgs routedEventArgs)
        {
            this.Visibility=Visibility.Hidden;
            ProgressBar car = new ProgressBar();
            car.Show();

        }
    }
}
