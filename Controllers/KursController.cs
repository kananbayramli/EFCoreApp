using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EFCoreApp.Data;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace EFCoreApp.Controllers;


public class KursController : Controller
{

    private readonly DataContext _context;
    public KursController(DataContext context)
    {
        _context = context;
    }


    public async Task<IActionResult> Index()
    {
        var kurslar =await  _context.Kurslar.Include(ogr => ogr.Ogretmen).ToListAsync();
        return View(kurslar);
    }


    public async Task<IActionResult> Create()
    {
        ViewBag.Ogretmenler = new SelectList(await _context.Ogretmenler.ToListAsync(), "OgretmenId", "AdSoyad");
        return View();
    }



    [HttpPost]
    public async Task<IActionResult> Create(Kurs kurs)
    {
        _context.Kurslar.Add(kurs);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }


    public async Task<IActionResult> Edit(int? id)
    {
        if(id == null){return NotFound();}

        var krs = await _context.Kurslar.Include(k => k.KursKayitLari).ThenInclude( k => k.Ogrenci).FirstOrDefaultAsync(k => k.KursId == id);

        if(krs == null){ return NotFound();}

        return View(krs);
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Kurs kurs)
    {
        if(id != kurs.KursId){return NotFound();}

        if(ModelState.IsValid)
        {
            try
            {
                _context.Update(kurs);
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                if(!_context.Kurslar.Any(k => k.KursId == kurs.KursId))
                {
                    return NotFound();
                }
                else{ throw;}
            }
            return RedirectToAction("Index");
        }
        return View(kurs);
    }


    public async Task<IActionResult> Delete(int? id)
    {
        if(id == null){return NotFound();}
        
        var krs = await _context.Kurslar.FindAsync(id);

        if(krs == null){return NotFound();}

        return View(krs);
    }


    [HttpPost]
    public async Task<IActionResult> Delete([FromForm] int id)
    {
        var krs = await _context.Kurslar.FindAsync(id);

        if(krs == null){return NotFound();}

        _context.Remove(krs);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");

    }

}