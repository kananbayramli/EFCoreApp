using EFCoreApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreApp.Controllers;

public class OgrenciController : Controller
{
    private readonly DataContext _context;
    public OgrenciController(DataContext context)
    {
        _context = context;
    }


    public async Task<IActionResult> Index()
    {
        var ogrenciler =await  _context.Ogrenciler.ToListAsync();
        return View(ogrenciler);
    }

    public IActionResult Create()
    {
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> Create(Ogrenci model)
    {
        _context.Ogrenciler.Add(model);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }


    public async Task<IActionResult> Edit(int? id)
    {
        if(id == null)
        {return NotFound();}

        var tlb = await _context
                                .Ogrenciler
                                .Include(t => t.KursKayitlari)
                                .ThenInclude(t => t.Kurs)
                                .FirstOrDefaultAsync(t => t.OgrenciId == id);
        //var tlbr = await _context.Ogrenciler.FirstOrDefaultAsync(t => t.OgrenciId == id);

        if(tlb == null)
        {return NotFound();}

        return View(tlb);
    }



    [HttpPost]
    [ValidateAntiForgeryToken]

    public async Task<IActionResult> Edit(int id, Ogrenci model)
    {
        if(id != model.OgrenciId){ return NotFound();}

        if(ModelState.IsValid)
        {
            try
            {
                _context.Update(model);
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                if(!_context.Ogrenciler.Any(t => t.OgrenciId == model.OgrenciId))
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

        var tlb = await _context.Ogrenciler.FindAsync(id);

        if(tlb == null){return NotFound();}

        return View(tlb);
    }


    [HttpPost]
    public async Task<IActionResult> Delete([FromForm]int id)
    {
        var tlb = await _context.Ogrenciler.FindAsync(id);

        if(tlb == null){ return NotFound();}

        _context.Remove(tlb);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }



}