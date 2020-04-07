using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using viewcomponent.tutorial.web.Models;
using viewcomponent.tutorial.web.Repositories;

namespace viewcomponent.tutorial.web.ViewComponents
{
    //[ViewComponent(Name="PriorityList")]
    public class PriorityListViewComponent : ViewComponent
    {
        private readonly TodoDbContext todoContext;

        public PriorityListViewComponent(TodoDbContext todoContext)
        {
            this.todoContext = todoContext;
        }

        public async Task<IViewComponentResult> InvokeAsync(int maxPriority, bool isDone)
        {
            var items = await GetItemsAsync(maxPriority, isDone);
            return View(items);
        }

        private Task<List<TodoItem>> GetItemsAsync(int maxPriority, bool isDone)
        {
            return todoContext.ToDo.Where(x => x.IsDone == isDone &&
                x.Priority <= maxPriority).ToListAsync();
        }
    }
}
