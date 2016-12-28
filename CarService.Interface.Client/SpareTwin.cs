using System;
using CarService.Core.Entities;

namespace CarService.Interface.Client
{
    //Use to show spares in listview
    public class SpareTwin
    {
        
        public string Code { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string Currency { get; set; }
        public int MarkupPercentage { get; set; }
        public double TotalPrice { get; set; }
        public string Description { get; set; }

    }
}