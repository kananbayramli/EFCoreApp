using EFCoreApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreApp.Controllers;

public class OgretmenController : Controller
{
    private readonly DataContext _context;

    public OgretmenController(DataContext context)
    {
        _context = context;
    }


    public async Task<IActionResult> Index()
    {
        var ogretmenler = await _context.Ogretmenler.ToListAsync();
        return View(ogretmenler);
    }


    public IActionResult Create()
    {
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> Create(Ogretmen model)
    {
        if(model != null)
        {
             _context.Ogretmenler.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        return NotFound();
    }

}