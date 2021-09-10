using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TaskForIntern.Models;

namespace TaskForIntern.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _db = db;
            _logger = logger;
        }

        public List<TodoItemModel> toDoItems { get; set; }
        public IActionResult Index()
        {
            toDoItems = _db.toDoItems.ToList();
            return View(toDoItems);
        }


        [HttpPost]
        public IActionResult AddToTable()
        {
            var postData = HttpContext.Request.Form["toDoText"];
            try
            {
                if (ModelState.IsValid)
                {
                    var newItem = new TodoItemModel();
                    newItem.ToDoItem = postData;
                    _db.Add(newItem);
                    _db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
