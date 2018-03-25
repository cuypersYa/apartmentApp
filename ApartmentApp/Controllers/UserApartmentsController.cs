using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ApartmentApp.Data;
using ApartmentApp.Models;

namespace ApartmentApp.Controllers
{
    public class UserApartmentsController : Controller
    {
        private readonly ApartmentContext _context;

        public UserApartmentsController(ApartmentContext context)
        {
            _context = context;
        }

        // GET: UserApartments
        public async Task<IActionResult> Index()
        {
            var apartmentContext = _context.UserApartments.Include(u => u.Apartment).Include(u => u.User);
            return View(await apartmentContext.ToListAsync());
        }

        // GET: UserApartments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userApartment = await _context.UserApartments
                .Include(u => u.Apartment)
                .Include(u => u.User)
                .SingleOrDefaultAsync(m => m.UserApartmentID == id);
            if (userApartment == null)
            {
                return NotFound();
            }

            return View(userApartment);
        }

        // GET: UserApartments/Create
        public IActionResult Create()
        {
            ViewData["ApartmentID"] = new SelectList(_context.Apartments, "ApartmentID", "Name");
            ViewData["UserID"] = new SelectList(_context.Users, "ID", "LastName");
            return View();
        }

        // POST: UserApartments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserApartmentID,UserID,ApartmentID,Owner,Resident")] UserApartment userApartment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userApartment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApartmentID"] = new SelectList(_context.Apartments, "ApartmentID", "Name", userApartment.ApartmentID);
            ViewData["UserID"] = new SelectList(_context.Users, "ID", "LastName", userApartment.UserID);
            return View(userApartment);
        }

        // GET: UserApartments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userApartment = await _context.UserApartments.SingleOrDefaultAsync(m => m.UserApartmentID == id);
            if (userApartment == null)
            {
                return NotFound();
            }
            ViewData["ApartmentID"] = new SelectList(_context.Apartments, "ApartmentID", "Name", userApartment.ApartmentID);
            ViewData["UserID"] = new SelectList(_context.Users, "ID", "LastName", userApartment.UserID);
            return View(userApartment);
        }

        // POST: UserApartments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserApartmentID,UserID,ApartmentID,Owner,Resident")] UserApartment userApartment)
        {
            if (id != userApartment.UserApartmentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userApartment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserApartmentExists(userApartment.UserApartmentID))
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
            ViewData["ApartmentID"] = new SelectList(_context.Apartments, "ApartmentID", "Name", userApartment.ApartmentID);
            ViewData["UserID"] = new SelectList(_context.Users, "ID", "LastName", userApartment.UserID);
            return View(userApartment);
        }

        // GET: UserApartments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userApartment = await _context.UserApartments
                .Include(u => u.Apartment)
                .Include(u => u.User)
                .SingleOrDefaultAsync(m => m.UserApartmentID == id);
            if (userApartment == null)
            {
                return NotFound();
            }

            return View(userApartment);
        }

        // POST: UserApartments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userApartment = await _context.UserApartments.SingleOrDefaultAsync(m => m.UserApartmentID == id);
            _context.UserApartments.Remove(userApartment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserApartmentExists(int id)
        {
            return _context.UserApartments.Any(e => e.UserApartmentID == id);
        }
    }
}
