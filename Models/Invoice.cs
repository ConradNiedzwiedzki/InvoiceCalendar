using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceCalendar.Models
{
    public class Invoice
    {
        public int ID { get; set; }

        [Display(Name = "Nazwa firmy")]
        public string Company { get; set; }

        [Display(Name = "Kwota faktury")]
        public double Price { get; set; }

        [Display(Name = "Data faktury")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CreatedDate { get; set; }
    }
}
