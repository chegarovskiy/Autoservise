using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarService.Core.Entities
{
    public class TimeStamp
    {
        public TimeStamp()
        {
            Modified = DateTime.Now;
        }

        [Column(TypeName = "datetime2")]
        public DateTime Modified { get; set; }
    }
}