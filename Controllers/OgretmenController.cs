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


    public async Task<IActionResult> Edit(int? id)
    {
        if(id == null){return NotFound();}

        var ogr = await _context
                                .Ogretmenler
                                .FirstOrDefaultAsync(t => t.OgretmenId == id);
        if(ogr == null){return NotFound();}

        return View(ogr);
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Ogretmen model)
    {
        if(id != model.OgretmenId){ return NotFound();}

        if(ModelState.IsValid)
        {
            try
            {
                _context.Update(model);
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                if(!_context.Ogretmenler.Any(t => t.OgretmenId == model.OgretmenId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction("Index");
        }
        return View(model);
    }






    public async Task<IActionResult> Delete(int? id)
    {
        if(id == null){return NotFound();}

        var ogr = await _context.Ogretmenler.FindAsync(id);

        if(ogr == null){return NotFound();}

        return View(ogr);
    }
}