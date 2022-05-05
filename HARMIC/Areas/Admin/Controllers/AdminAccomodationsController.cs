using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HARMIC.Models;
using PagedList.Core;

namespace HARMIC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminAccomodationsController : Controller
    {
        private readonly Travel_BookerContext _context;

        public AdminAccomodationsController(Travel_BookerContext context)
        {
            _context = context;
        }

        // GET: Admin/AdminAccomodations
        public async Task<IActionResult> Index(int page =1, int CategoryId =0)
        {
            var pageNumber = page;
            var pageSize = 20/* Utilities.PAGE_SIZE*/;
            List<Accomodation> IsAccomodations = new List<Accomodation>();
            if (CategoryId != 0)
            {
                IsAccomodations = _context.Accomodations
                .AsNoTracking()
                .Where(x => x.CategoryId == CategoryId)
                .Include(x => x.Category)
                .OrderByDescending(x => x.AccomodationId).ToList();
            }
            else
            {
                IsAccomodations = _context.Accomodations
                .AsNoTracking()
                .Include(x => x.Category)
                .OrderByDescending(x => x.AccomodationId).ToList();
            }
            PagedList<Accomodation> models = new PagedList<Accomodation>(IsAccomodations.AsQueryable(), pageNumber, pageSize);
            ViewBag.CurrentCateID = CategoryId;
            ViewBag.CurrentPage = pageNumber;
            ViewData["DanhMuc"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", CategoryId);
            return View(models);
        }
        public IActionResult Filtter(int CategoryId = 0)
        {
            var url = $"/Admin/AdminAccomodations?CategoryId={CategoryId}";
            if(CategoryId == 0)
            {
                url = $"/Admin/AdminAccomodations";
            }
            return Json(new { status = "success", redirectUrl = url });
        }

        // GET: Admin/AdminAccomodations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accomodation = await _context.Accomodations
                .FirstOrDefaultAsync(m => m.AccomodationId == id);
            if (accomodation == null)
            {
                return NotFound();
            }

            return View(accomodation);
        }

        // GET: Admin/AdminAccomodations/Create
        public IActionResult Create()
        {
            ViewData["DanhMuc"] = new SelectList(_context.Categories, "CategoryId", "CategoryName");
            return View();
        }

        // POST: Admin/AdminAccomodations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AccomodationId,AccomodationName,CategoryName,Address,PhoneNumber,City,Country,Description,Image,Rate")] Accomodation accomodation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(accomodation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DanhMuc"] = new SelectList(_context.Categories, "CategoryId", "CategoryName",accomodation.CategoryId);
            return View(accomodation);
        }

        // GET: Admin/AdminAccomodations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accomodation = await _context.Accomodations.FindAsync(id);
            if (accomodation == null)
            {
                return NotFound();
            }
            ViewData["DanhMuc"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", accomodation.CategoryId);
            return View(accomodation);
        }

        // POST: Admin/AdminAccomodations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AccomodationId,AccomodationName,CategoryName,Address,PhoneNumber,City,Country,Description,Image,Rate")] Accomodation accomodation)
        {
            if (id != accomodation.AccomodationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accomodation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccomodationExists(accomodation.AccomodationId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["DanhMuc"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", accomodation.CategoryId);
            return View(accomodation);
        }

        // GET: Admin/AdminAccomodations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accomodation = await _context.Accomodations
                .FirstOrDefaultAsync(m => m.AccomodationId == id);
            if (accomodation == null)
            {
                return NotFound();
            }

            return View(accomodation);
        }

        // POST: Admin/AdminAccomodations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var accomodation = await _context.Accomodations.FindAsync(id);
            _context.Accomodations.Remove(accomodation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccomodationExists(int id)
        {
            return _context.Accomodations.Any(e => e.AccomodationId == id);
        }
    }
}
