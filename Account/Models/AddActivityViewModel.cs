using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Account.Models
{
    public class AddActivityViewModel
    {
        [Display(Name = "活動名稱")]
        public string Name { get; set; }

        [Display(Name = "開始時間")]
        public DateTime StartDate { get; set; }

        [Display(Name = "結束時間")]
        public DateTime EndDate { get; set; }

        [Display(Name = "活動地址")]
        public string Address { get; set; }

        [Display(Name = "價格")]
        public decimal Price { get; set; }
    }
}