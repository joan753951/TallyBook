using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TallyBook.Models.ViewModels;

namespace TallyBook.Models
{
    public class AccountBookService
    {
        private readonly SkillTreeHomeworkEntities _db;

        public AccountBookService()
        {
            _db = new SkillTreeHomeworkEntities();
        }

        public virtual TallyBookViewModel QueryAll()
        {
            TallyBookViewModel result = new TallyBookViewModel();
            var selector = _db.AccountBook
                .Select(p => new TallyBookViewModel()
                {
                    Type = (p.Categoryyy.ToString() == "1" ? "支出" : "收入"),
                    Date = p.Dateee,
                    Money = p.Amounttt,
                    Remark = p.Remarkkk
                });
            result.TallyBook = selector.AsNoTracking()
                                .ToList();
            return result;
        }
    }
}