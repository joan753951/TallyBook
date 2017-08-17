using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TallyBook.Models;
using TallyBook.Models.ViewModels;
using TallyBook.Repositories;

namespace TallyBook.Controllers
{
    public class TallyBookController : Controller
    {
        private readonly AccountBookService _accountbookSvc;

        public TallyBookController()
        {
            var unitOfWork = new UnitOfWork();
            _accountbookSvc = new AccountBookService(unitOfWork);
        }

        // GET: TallyBook
        public ActionResult TallyBook()
        {
            return View();
        }
        public ActionResult TallyBookChildAction()
        {
            return View(_accountbookSvc.QueryAll());
        }
    }
}