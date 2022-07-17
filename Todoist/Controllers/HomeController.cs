using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Todoist.Models;

namespace Todoist.Controllers;

public class HomeController : Controller
{
    private ApplicationContext _db;

    public HomeController(ApplicationContext context)=>
        _db = context;

    public async Task<IActionResult> Index()=>
        View(await _db.Tasks.ToListAsync());

    public IActionResult CreateTask()=>
        View();

    [HttpPost]
    public async Task<IActionResult> CreateTask(Models.Task task)
    {
        if (ModelState.IsValid)
        {
            _db.Tasks.Add(task);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        return View(task);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int? id)
    {
        if (id != null)
        {
            Models.Task? task = await _db.Tasks.FirstOrDefaultAsync(p => p.Id == id);
            if (task != null)
            {
                _db.Tasks.Remove(task);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
        }
        return NotFound();
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id != null)
        {
            Models.Task? task = await _db.Tasks.FirstOrDefaultAsync(p => p.Id == id);
            if (task != null) return View(task);
        }
        return NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Models.Task task)
    {
        _db.Tasks.Update(task);
        await _db.SaveChangesAsync();
        return RedirectToAction("Index");
    }
}

