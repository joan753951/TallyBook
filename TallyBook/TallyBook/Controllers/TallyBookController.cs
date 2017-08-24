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
            var items = new List<SelectListItem>
            {
                new SelectListItem { Value = "0", Text = "收入" },
                new SelectListItem { Value = "1", Text = "支出" }
            };
            ViewData["item"] = items;

            return View();
        }

        public ActionResult TallyBookDateValidate(DateTime Date)
        {
            bool isValidate = Date <= DateTime.Now;
            return Json(isValidate, JsonRequestBehavior.AllowGet);
        }

        public ActionResult TallyBookChildAction()
        {
            return View(_accountbookSvc.Lookup());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Type,Date,Money,Remark")] TallyBookViewModel accountbook)
        {
            if (ModelState.IsValid)
            {
                _accountbookSvc.Add(accountbook);
                _accountbookSvc.Save();

                return RedirectToAction("TallyBook");
            }
            var result = new TallyBookViewModel()
            {
                Type = accountbook.Type,
                Date = accountbook.Date,
                Money = accountbook.Money,
                Remark = accountbook.Remark,
            };
            return View(result);
        }
    }
}