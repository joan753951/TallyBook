using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TallyBook.Models.ViewModels;

namespace TallyBook.Controllers
{
    public class TallyBookController : Controller
    {
        // GET: TallyBook
        public ActionResult TallyBook()
        {
            return View();
        }
        public ActionResult TallyBookChildAction()
        {
            List<TallyBookViewModel> TallyBookData = new List<TallyBookViewModel>
            {
                new TallyBookViewModel() { Type = "支出", Date = DateTime.Now.AddDays(1), Money = 1000},
                new TallyBookViewModel() { Type = "支出", Date = DateTime.Now.AddDays(2), Money = 2000 },
                new TallyBookViewModel() { Type = "支出", Date = DateTime.Now.AddDays(3), Money = 3000 },
                new TallyBookViewModel() { Type = "支出", Date = DateTime.Now.AddDays(4), Money = 4000 },
                new TallyBookViewModel() { Type = "支出", Date = DateTime.Now.AddDays(5), Money = 5000 },
            };
            var viewModel = new TallyBookViewModel
            {
                TallyBook = TallyBookData
            };
            return View(viewModel);
        }
    }
}