using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace TallyBook.Models.ViewModels
{
    public class TallyBookViewModel
    {
        public List<TallyBookViewModel> TallyBook { get; set; }

        [Display(Name = "類別")]
        public string Type { get; set; }

        [Range(1, 2147483647)]
        [Display(Name = "金額")]
        public int Money { get; set; }

        [Remote("TallyBookDateValidate",  "TallyBook", ErrorMessage = "日期不得大於今天")]
        [Display(Name = "日期")]
        public DateTime Date { get; set; }

        [StringLength(100, MinimumLength = 0, ErrorMessage = "最多輸入100字元！")]
        [Display(Name = "備註")]
        public string Remark { get; set; }
    }
}