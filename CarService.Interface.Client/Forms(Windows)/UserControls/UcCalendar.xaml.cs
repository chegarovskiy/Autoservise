using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using CarService.Core.BusinessLogicLayer;

using CarService.Service.CarWcfServer;


namespace CarService.Interface.Client.Forms_Windows_.UserControls
{
    /// <summary>
    /// Interaction logic for UcCalendar.xaml
    /// </summary>
    public partial class UcCalendar : UserControl
    {
        private readonly CarAppService _client = new CarAppService();
        private Guid _workerId = Guid.Empty;
        private TimePeriod _currentPeriod = TimePeriod.Day;
        //private List<OrderedService> services=_client.GetAllOrders().Where()
        public UcCalendar()
        {
            
            InitializeComponent();

            lblChosenData.Content = DateTime.Now.ToLongDateString();

            BuildTreeView();
            DrawChoosenButton();

            ShowUserWorks(_workerId);

        }

        private void ConcreteUser_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            _workerId = Guid.Parse(((TreeViewItem) sender).Uid);

            ShowUserWorks(_workerId);

            _workerId = Guid.Empty;
            e.Handled = true;
        }

        private void MyItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void CalendarOfWork_OnSelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CalendarOfWork.SelectedDate != null)
                lblChosenData.Content = CalendarOfWork.SelectedDate.Value.ToLongDateString();
        }

        private void BuildTreeView()
        {
            
            _client.GetWorkTypes();


            foreach (var workType in _client.GetWorkTypes().OrderBy(x=>x.WorkName).ThenBy(x=>x.Users.OrderBy(worker=>worker.FirstName)))
            {
                var myItem = new TreeViewItem()
                {
                    Header = workType.WorkName, Uid = workType.Id.ToString() 
                };

                myItem.MouseDoubleClick += MyItem_MouseDoubleClick;
                TreeViewWorkersAndWork.Items.Add(myItem);
                foreach (var user in workType.Users)
                {
                    var concreteUser = new TreeViewItem
                    {
                        Header = user.FirstName,
                        Name = user.Login,
                        Uid = user.Id.ToString()
                    };
                    concreteUser.PreviewMouseDoubleClick += ConcreteUser_MouseDoubleClick;
                    myItem.Items.Add(concreteUser);
                }
            }
        }

        private void ShowUserWorks(Guid id )
         {
            //todo get list from db according to worker id
            var thisList = _client.GetUserOrdersForPeriod(_workerId, DateTime.Today, _currentPeriod);
            //if (CalendarOfWork.SelectedDate != null)
            if (CalendarOfWork.SelectedDate == null)
                lvWorks.ItemsSource = _client.GetUserOrdersForPeriod(_workerId, DateTime.Today, _currentPeriod);
            else
                lvWorks.ItemsSource = _client.GetUserOrdersForPeriod(_workerId, CalendarOfWork.SelectedDate.Value, _currentPeriod);
            
        }

        private void BtnShowDay_OnClick(object sender, RoutedEventArgs e)
        {
            _currentPeriod = TimePeriod.Day;
            DrawChoosenButton();
            ShowUserWorks(_workerId);
        }

        private void BtnShowWeek_OnClick(object sender, RoutedEventArgs e)
        {
            _currentPeriod = TimePeriod.Week;
            DrawChoosenButton();
            ShowUserWorks(_workerId);

        }

        private void BtnShowMonth_OnClick(object sender, RoutedEventArgs e)
        {
            _currentPeriod = TimePeriod.Month;
            DrawChoosenButton();
            ShowUserWorks(_workerId);

        }

        //Set background color for choosen button
        private void DrawChoosenButton()
        {
            switch (_currentPeriod)
            {
                    case TimePeriod.Day:
                        btnShowDay.Background = Brushes.CornflowerBlue;
                        btnShowWeek.Background = Brushes.LightGray;
                        btnShowMonth.Background = Brushes.LightGray;
                    break;
                    case TimePeriod.Week:
                        btnShowDay.Background = Brushes.LightGray;
                        btnShowWeek.Background = Brushes.CornflowerBlue;
                        btnShowMonth.Background = Brushes.LightGray;
                    break;
                    case TimePeriod.Month:
                        btnShowDay.Background = Brushes.LightGray;
                        btnShowWeek.Background = Brushes.LightGray;
                        btnShowMonth.Background = Brushes.CornflowerBlue;
                    break;
            }
        }
    }
}
