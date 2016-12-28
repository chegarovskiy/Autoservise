using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Globalization;
using System.Windows;
using System.Windows.Forms;
using CarService.Core.BusinessLogicLayer;
using CarService.Core.BusinessLogicLayer.Implementations;
using CarService.Core.DataAccessLayer.Repositories;
using CarService.Core.DataAccessLayer.Repositories.Implementations;
using CarService.Core.Entities;
using MessageBox = System.Windows.MessageBox;
using UserControl = System.Windows.Controls.UserControl;
using DataTable = System.Data.DataTable;

namespace CarService.Interface.Client.Forms_Windows_.UserControls
{
    /// <summary>
    /// Логика взаимодействия для SpareParts.xaml
    /// </summary>
    public partial class SpareParts : UserControl
    {
        string filePath = String.Empty;
        public DataTable dt;

        public SpareParts()
        {
            InitializeComponent();
        }

        private void BtLoadPrise_OnClick(object sender, RoutedEventArgs e)
        // открытие файла и вычитка items по заданному шаблону
        {
            try
            {
                OpenFileDialog openFile = new OpenFileDialog();
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFile.FileName;

                    String connString = ("Provider=Microsoft.ACE.OLEDB.12.0;" +
                                         "Data Source=" + filePath + ";" +
                                         "Extended Properties=Excel 12.0 Xml");
                    OleDbConnection conn = new OleDbConnection(connString);

                    OleDbDataAdapter myDataAdapter = new OleDbDataAdapter("SELECT * FROM [list1$]", conn);

                    dt = new DataTable();

                    myDataAdapter.Fill(dt);
                }
                /*--------------------------------------------------------------------------------------------------------------------------*/
                int countSpares = dt.Rows.Count;
                var spareContext = new SpareBuisnessLogic(new SpareRepository());

                var mamufactureContext = new ManufactureBusinessLogic(new ManufactureRepository());
                    // создаем обьект контекста производителя
                // var spareContext = new SpareRepository(); // создаем обьект контекста запчасти

                var currensyContext = new CurrenceBusinessLogic(new CurrencyRepository());
                    // создаем обьект контекста валюты

                var manufactueresList = new List<Manufacturer>();
                var sparesList = new List<Spare>();

                for (int i = 5; i < 10; i++) // пробегаемся по всем запчастям
                {
                    Spare currentSpare = new Spare(); // создаем обьект запчасти
                    Currency currrentCurrency = new Currency(); // создаем обьект валюты
                    Manufacturer currentManufacturer = new Manufacturer();

                    

                    string nameCurrency = dt.Rows[i][9].ToString();
                    string nameManudacture = dt.Rows[i][2].ToString();
                    string codeSpare = dt.Rows[i][1].ToString();
                    string nameSpare = dt.Rows[i][3].ToString();
                    string descriptionSpare = dt.Rows[i][4].ToString();
                    string quantitySpare = dt.Rows[i][6].ToString();

                    // toDo заполнять сначала это поле из интернета текущим курсом валюты 
                    string exchngeRate = dt.Rows[i][10].ToString();
                    int quantitySpareInt = Int32.Parse(quantitySpare);

                   


                    //    currentManufacturer = mamufactureContext.FindManufacturer(nameManudacture);
                    //    if (string.IsNullOrEmpty(nameManudacture))
                    //    {
                    //        MessageBox.Show($" x{nameManudacture}", "хрень", MessageBoxButton.OK);
                    //    }
                    //    else if (currentManufacturer == null)
                    //    {
                    //        currentManufacturer = new Manufacturer()
                    //        {
                    //            Name = nameManudacture,
                    //            IsDeleted = false,
                    //            Modified = DateTime.Now,
                    //            Description = descriptionSpare,
                    //        };
                    //        manufactueresList.Add(currentManufacturer);
                    //    }
                    //}
                    //mamufactureContext.InsertRange(manufactueresList);
                    //mamufactureContext.SaveChanges();


                    var result = 0.0;
                    if (double.TryParse(dt.Rows[i][5].ToString(), NumberStyles.AllowDecimalPoint,
                        CultureInfo.InvariantCulture, out result))
                    {
                        currentSpare = new Spare()
                        {
                            Code = codeSpare,
                            Description = descriptionSpare,
                            Manufacturer = spareContext.AttachManufacturer(nameManudacture),
                            Currency = spareContext.AttachCurrency(nameCurrency),
                            MarkupPercentage = 20,
                            Name = nameSpare,
                            Price = result,
                            Quantity = quantitySpareInt,
                            Modified = DateTime.Now,
                            IsDeleted = false
                        };
                       
                        sparesList.Add(currentSpare);
                    }
                }
                spareContext.InsertRange(sparesList);
                spareContext.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.ToString()}", "хрень", MessageBoxButton.OK);
            }

        }

    }

}

/*    var currrentCurrency = currensyContext.FindCurrensy(nameCurrency);
     if (currrentCurrency == null)
     {
         MessageBox.Show($"хрень с валютой{nameCurrency}", "хрень", MessageBoxButton.OK);
         // currensyContext.AddCurrency(nameCurrenc);
         // break;
     }

     Int32.TryParse(quantitySpare, out quantitySpareInt);
*/
// если такого производителя еще нету в списке базы производителей
/*                {


                    var result = 0.0;
                    if (double.TryParse(dt.Rows[i][5].ToString(), NumberStyles.AllowDecimalPoint,
                        CultureInfo.InvariantCulture, out result))
                        currentSpare = new Spare()
                        {
                            Code = codeSpare,
                            Description = descriptionSpare,
                            Manufacturer = currentManufacturer,
                            Currency = currrentCurrency,
                            MarkupPercentage = 20,
                            Name = nameSpare,
                            Price = result,
                            Quantity = quantitySpareInt,
                            Modified = DateTime.Now,
                            IsDeleted = false,

                        };
                    sparesList.Add(currentSpare);

                }
                else
                {
                    var result = 0.0;
                    if (double.TryParse(dt.Rows[i][5].ToString(), NumberStyles.AllowDecimalPoint,
                        CultureInfo.InvariantCulture, out result))
                    {
                        currentSpare = new Spare()
                        {
                            Code = codeSpare,
                            Description = descriptionSpare,
                            Manufacturer = currentManufacturer,
                            Currency = currrentCurrency,
                            MarkupPercentage = 20,
                            Name = nameSpare,
                            Price = result,
                            Quantity = quantitySpareInt,
                            Modified = DateTime.Now,
                            IsDeleted = false
                        };
                     //   spareContext.Insert(currentSpare);
                        sparesList.Add(currentSpare);
                    }
                }
            }

            spareContext.InsertRange(sparesList);
            spareContext.SaveChanges();




        }

    }
    catch (Exception ex)
    {
        MessageBox.Show($"{ex.ToString()}", "хрень", MessageBoxButton.OK);

    }

}
}
}
*/
