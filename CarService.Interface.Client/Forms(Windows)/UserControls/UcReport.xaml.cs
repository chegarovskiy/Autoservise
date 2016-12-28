using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using CarService.Core.Entities;
using CarService.Service.CarWcfServer;


namespace CarService.Interface.Client.Forms_Windows_.UserControls
{
    /// <summary>
    /// Interaction logic for UcCalendar.xaml
    /// </summary>
    public partial class UcReport : UserControl
    {
        private int _itemsInReportCount = 0;

        public struct ReportItem
        {
            public string Number { get; set; }
            public string User { get; set; }
            public string Name { get; set; }
            public string Date { get; set; }
            public string Summ { get; set; }
        };

        private enum ReportType
        {
            ChoseMenu = 0,
            Order,
            Service,
            Spare,
            TotalRevenue
        }

        public UcReport()
        {
            InitializeComponent();
            lbInputError.Visibility = Visibility.Hidden;
            cbTypeReport.SelectedIndex = (int) ReportType.ChoseMenu;
            DtpDateFrom.SelectedDate = DateTime.Now;

        }

        private void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            var dateFrom = DtpDateFrom.SelectedDate;
            var dateTo = DtpDateTo.SelectedDate;
            var typeReportIndex = cbTypeReport.SelectedIndex;
            if (dateFrom == null || dateTo == null || (dateFrom > dateTo))
            {
                lbInputError.Content = "Date input error";
                lbInputError.Visibility = Visibility.Visible;
                lbInputError.Foreground = new SolidColorBrush(Colors.Red);
                return;
            }

            if (typeReportIndex == (int) ReportType.ChoseMenu)
            {
                lbInputError.Content = "Error report type";
                lbInputError.Visibility = Visibility.Visible;
                lbInputError.Foreground = new SolidColorBrush(Colors.Red);
                return;
            }


            lbInputError.Visibility = Visibility.Hidden;
            LoadReport(dateFrom.Value, dateTo.Value, typeReportIndex);

        }

        private void LoadReport(DateTime dateFrom, DateTime dateTo, int typeReportIndex)
        {
            lvReportInfo.Items.Clear();
            var totalPrice = 0.0;

            switch (typeReportIndex)
            {
                case (int) ReportType.Order:
                    _itemsInReportCount = 0;
                    totalPrice = LoadOrderReport(dateFrom, dateTo);
                    AddSummary(totalPrice);
                    break;
                case (int) ReportType.Service:
                    _itemsInReportCount = 0;
                    totalPrice = LoadServiceReport(dateFrom, dateTo);
                    AddSummary(totalPrice);
                    break;
                case (int) ReportType.Spare:
                    _itemsInReportCount = 0;
                    totalPrice = LoadSpareReport(dateFrom, dateTo);
                    AddSummary(totalPrice);
                    break;
                case (int) ReportType.TotalRevenue:
                    _itemsInReportCount = 0;
                    totalPrice += LoadOrderReport(dateFrom, dateTo);
                    totalPrice += LoadServiceReport(dateFrom, dateTo);
                    totalPrice += LoadSpareReport(dateFrom, dateTo);
                    AddSummary(totalPrice);
                    break;
            }

        }

        private void AddSummary(double totalPrice)
        {
            var summary = new ReportItem
            {
                Date = "Summary:",
                Summ = totalPrice.ToString(CultureInfo.InvariantCulture)
            };
            lvReportInfo.Items.Add(summary);
        }

        private double LoadServiceReport(DateTime dateFrom, DateTime dateTo)
        {
            var totalPrice = 0.0;
            try
            {
                var orderedServices = new CarAppService().GetAllOrderedServices();
                var doneServicesByDates = new List<OrderedService>();

                foreach (var service in orderedServices)
                {
                    if (service.Order.EndDate >= dateFrom && service.Order.EndDate <= dateTo.AddDays(1))
                    {
                        doneServicesByDates.Add(service);
                    }
                }

                if (doneServicesByDates.Count > 0)
                {
                    foreach (var service in doneServicesByDates)
                    {
                        var item = new ReportItem();
                        item.Number = (++_itemsInReportCount).ToString();
                        item.User = service.User.FirstName;
                        item.Name = service.Service.Name;
                        item.Date = service.Order.EndDate.ToShortDateString();
                        item.Summ = service.FinalPrice.ToString(CultureInfo.InvariantCulture);

                        lvReportInfo.Items.Add(item);

                        totalPrice += service.FinalPrice;
                    }

                    tbReportOwner.Text = doneServicesByDates.FirstOrDefault()?.User.FirstName;
                    tbReportDate.Text = DateTime.Now.ToString(CultureInfo.InvariantCulture);
                }
                else
                {
                    lvReportInfo.Items.Add(new ReportItem { User = "No SERVICE data to show" });
                }
            }
            catch (Exception)
            {
                lvReportInfo.Items.Add(new ReportItem { User = "No SERVICE data to show" });
            }
            return totalPrice;
        }



        private double LoadSpareReport(DateTime dateFrom, DateTime dateTo)
        {
            var totalPrice = 0.0;
            try
            {
                var orderedSpares = new CarAppService().GetAllOrderedSpares();
                var boughtSparesByDates = new List<OrderedSpare>();
                foreach (var spare in orderedSpares)
                {
                    if (spare.Order.EndDate >= dateFrom && spare.Order.EndDate <= dateTo.AddDays(1))
                    {
                        boughtSparesByDates.Add(spare);
                    }
                }

                if (boughtSparesByDates.Count > 0)
                {
                    foreach (var spare in boughtSparesByDates)
                    {
                        var item = new ReportItem();
                        item.Number = (++_itemsInReportCount).ToString();
                        item.User = spare.User.FirstName;
                        item.Name = spare.Spare.Name + " x " + spare.Count + " шт.";
                        item.Date = spare.Order.EndDate.ToShortDateString();
                        item.Summ = spare.PriceForAll.ToString(CultureInfo.InvariantCulture);

                        lvReportInfo.Items.Add(item);

                        totalPrice += spare.PriceForAll;
                    }

                    tbReportOwner.Text = boughtSparesByDates.FirstOrDefault()?.User.FirstName;
                    tbReportDate.Text = DateTime.Now.ToString(CultureInfo.InvariantCulture);
                }
                else
                {
                    lvReportInfo.Items.Add(new ReportItem { User = "No SPARE data to show" });
                }
            }
            catch (Exception)
            {
                lvReportInfo.Items.Add(new ReportItem { User = "No SPARE data to show" });
            }
            
            return totalPrice;
        }

        private double LoadOrderReport(DateTime dateFrom, DateTime dateTo)
        {
            var totalPrice = 0.0;
            try
            {
                var orders = new CarAppService().GetAllOrders();
                var ordersByDates = new List<Order>();
                foreach (var order in orders)
                {
                    if (order.EndDate >= dateFrom && order.EndDate <= dateTo.AddDays(1))
                    {
                        ordersByDates.Add(order);
                    }
                }

                if (ordersByDates.Count > 0)
                {
                    foreach (var order in ordersByDates)
                    {
                        var item = new ReportItem();
                        item.Number = (++_itemsInReportCount).ToString();
                        item.User = order.Client.FullName;
                        item.Name = "Ордер";
                        item.Date = order.EndDate.ToShortDateString();
                        item.Summ = order.TotalPrice.ToString(CultureInfo.InvariantCulture);

                        lvReportInfo.Items.Add(item);

                        totalPrice += order.TotalPrice;
                    }

                    tbReportOwner.Text = ordersByDates.FirstOrDefault()?.Client.FullName + " - employee";
                    tbReportDate.Text = DateTime.Now.ToString(CultureInfo.InvariantCulture);
                }
                else
                {
                    lvReportInfo.Items.Add(new ReportItem {User = "No data to show"});
                }
                
            }
            catch (Exception e)
            {
                lvReportInfo.Items.Add(new ReportItem { User = "No data to show" });
            }

            return totalPrice;

        }
    }
}
