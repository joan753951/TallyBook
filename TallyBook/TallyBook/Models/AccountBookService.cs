using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TallyBook.Models.ViewModels;
using TallyBook.Repositories;

namespace TallyBook.Models
{
    public class AccountBookService
    {
        private readonly IRepository<AccountBook> _accountbookRep;
        private readonly IUnitOfWork _unitOfWork;
        
        public AccountBookService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _accountbookRep = new Repository<AccountBook>(unitOfWork);
        }

        public virtual TallyBookViewModel Lookup()
        {
            TallyBookViewModel result = new TallyBookViewModel();
            var source = _accountbookRep.LookupAll();
            var selector = source.Select(p => new TallyBookViewModel()
            {
                Type = (p.Categoryyy.ToString() == "1" ? "支出" : "收入"),
                Date = p.Dateee,
                Money = p.Amounttt,
                Remark = p.Remarkkk
            });
            result.TallyBook = selector.AsNoTracking().OrderBy(p => p.Date)
                                .ToList();
            return result;
        }

        public void Add(TallyBookViewModel accountbook)
        {
            int.TryParse(accountbook.Type, out int category);
            var result = new AccountBook()
            {
                Id = Guid.NewGuid(),
                Categoryyy = category,
                Dateee = accountbook.Date,
                Amounttt = accountbook.Money,
                Remarkkk = accountbook.Remark,
            };
            _accountbookRep.Create(result);
        }

        public void Save()
        {
            _unitOfWork.Save();
        }
    }
}