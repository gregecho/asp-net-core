using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using viewcomponent.tutorial.web.Models;
using viewcomponent.tutorial.web.Repositories;

namespace viewcomponent.tutorial.web.Contollers
{
    public class TodoController : Controller
    {
        public TodoDbContext _TodoContext { get; set; }
        public TodoController(TodoDbContext todoContext)
        {
            this._TodoContext = todoContext;
        }

        public IActionResult Index()
        {
            List<TodoItem> todos = null;
            using(_TodoContext)
            {
                todos = _TodoContext.ToDo.ToList();
            }
            return View(todos);
        }
    }
}
