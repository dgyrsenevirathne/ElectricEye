using ElectricEye.Web.Data;
using ElectricEye.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ElectricEye.Web.Controllers
{
    
    public class AlertSettingsController : Controller
    {
        private readonly AppDbContext _context;

        public AlertSettingsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: AlertSettings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AlertSettings/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,Location,Threshold,AlertType")] AlertSetting alertSetting)
        {
            if (ModelState.IsValid)
            {
                _context.AlertSettings.Add(alertSetting);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index)); // Redirect to a list or summary page
            }
            return View(alertSetting);
        }

        // GET: AlertSettings/Index
        public async Task<IActionResult> Index()
        {
            var alertSettings = await _context.AlertSettings.ToListAsync();
            return View(alertSettings);
        }

        // GET: AlertSettings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alertSetting = await _context.AlertSettings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alertSetting == null)
            {
                return NotFound();
            }

            return View(alertSetting);
        }

        // POST: AlertSettings/Delete/5
        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var alertSetting = await _context.AlertSettings.FindAsync(id);
            if (alertSetting != null)
            {
                _context.AlertSettings.Remove(alertSetting);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: AlertSettings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alertSetting = await _context.AlertSettings.FindAsync(id);
            if (alertSetting == null)
            {
                return NotFound();
            }

            return View(alertSetting);
        }

        // POST: AlertSettings/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,Location,Threshold,AlertType")] AlertSetting alertSetting)
        {
            if (id != alertSetting.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alertSetting);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlertSettingExists(alertSetting.Id))
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
            return View(alertSetting);
        }

        private bool AlertSettingExists(int id)
        {
            return _context.AlertSettings.Any(e => e.Id == id);
        }




        // Additional methods for editing, deleting, etc., can be added as needed
    }
}
