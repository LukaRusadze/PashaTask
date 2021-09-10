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


        // Dependency Injection to get the database
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _db = db;
            _logger = logger;
        }

        public List<TodoItemModel> toDoItems { get; set; }

        // Index Page //
        // Passes list of To-Do items that's available in the database
        // so that it can be displayed on the index page 
        public IActionResult Index()
        {
            toDoItems = _db.toDoItems.ToList();
            return View(toDoItems);
        }

        // Handles the add To-Do item section on index page
        public IActionResult AddToTable(TodoItemModel postData)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _db.Add(postData);
                    _db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return RedirectToAction("Index");
        }

        // Handles delete buttons on To-Do items
        public IActionResult Delete(int ID)
        {
            try
            {
                var itemToBeDeleted = _db.toDoItems.Find(ID);

                if (itemToBeDeleted == null)
                {
                    return NotFound();
                }

                _db.Remove(itemToBeDeleted);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return RedirectToAction("Index");
        }

        // Edit Page
        public IActionResult Edit(int ID)
        {
            var itemToBeEdited = _db.toDoItems.Find(ID);
            return View(itemToBeEdited);
        }

        // Handles the save button on the Edit page
        public IActionResult EditPost(TodoItemModel editData)
        {
            var itemToBeEdited = _db.toDoItems.Find(editData.ID);

            if (itemToBeEdited == null)
            {
                return NotFound();
            }

            itemToBeEdited.ToDoItem = editData.ToDoItem;
            _db.SaveChanges();

            return RedirectToAction("Index");
        }


        // Error Page
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
