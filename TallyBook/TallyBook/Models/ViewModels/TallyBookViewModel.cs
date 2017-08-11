using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace TallyBook.Models.ViewModels
{
    public class TallyBookViewModel
    {
        public List<TallyBookViewModel> TallyBook { get; set; }

        [DisplayName("類別")]
        public string Type { get; set; }

        [DisplayName("金額")]
        public int Money { get; set; }

        [DisplayName("日期")]
        public DateTime Date { get; set; }

        [DisplayName("備註")]
        public string Remark { get; set; }
    }
}