using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CarService.Interface.Client.Helpers
{
    public  static  class  ProgressBar
    {
        private static readonly WindowsWpf.ProgressBar MyBar = new WindowsWpf.ProgressBar();

        public static void BackWorker()
        {
            BackgroundWorker worker = new BackgroundWorker {WorkerReportsProgress = true};
            worker.DoWork += worker_DoWork;
            worker.RunWorkerAsync();
        }

        public static void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            ShowProgressBar();
        }

        public static void ShowProgressBar()
        {
            MyBar.Visibility = Visibility.Visible;
        }

        public static void HideProgressBar()
        {
            MyBar.Visibility = Visibility.Hidden;
        }
    }
}
