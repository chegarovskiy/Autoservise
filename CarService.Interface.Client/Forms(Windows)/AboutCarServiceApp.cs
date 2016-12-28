using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarService.Interface.Client.Forms_Windows_
{
    partial class AboutCarServiceApp : Form
    {
        public AboutCarServiceApp()
        {
            InitializeComponent();
            this.Text = String.Format("About {0}", "Car Service");
            this.labelProductName.Text = @"С# command in IT Academy. Vinnitsia";
            this.labelVersion.Text = String.Format("Version {0}", "1.0.0");
            this.labelCopyright.Text = @"All rights reserved. " + AssemblyCopyright;
            this.labelCompanyName.Text = @"C# .Net team ITA";
            this.textBoxDescription.Text = @"This programm free for trial period(1 month). You can use it for organize your car service work. " +
                                           @"With best regards from our company!" + Environment.NewLine +
                                           Environment.NewLine + @"Delelop team:" + 
                                           Environment.NewLine + @"Maxim Gomon" + @", " + @"Vladyslav Mykhaylyuk" +
                                           Environment.NewLine + @"Anatoliy Rijavskii" + @", " + @"Vladyslav Chegarovskiy" +
                                           Environment.NewLine + @"Viktor Litvak"; ;
        }

        #region Assembly Attribute Accessors

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion
    }
}
