using ElectricEye.Web.Data;
using ElectricEye.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ElectricEye.Web.Controllers
{
    
    public class EnergyUsageController : Controller
    {
        private readonly AppDbContext _context;

        public EnergyUsageController(AppDbContext context)
        {
            _context = context;
        }

        // GET: EnergyUsage
        public async Task<IActionResult> Index()
        {
            return View(await _context.EnergyUsages.ToListAsync());
        }

        // GET: EnergyUsage/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EnergyUsage/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserName,Timestamp,Location,Consumption")] EnergyUsage energyUsage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(energyUsage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(energyUsage);
        }

        // GET: EnergyUsage/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var energyUsage = await _context.EnergyUsages.FindAsync(id);
            if (energyUsage == null)
            {
                return NotFound();
            }
            return View(energyUsage);
        }

        // POST: EnergyUsage/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserName,Timestamp,Location,Consumption")] EnergyUsage energyUsage)
        {
            if (id != energyUsage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(energyUsage);
                    await _context.SaveChangesAsync();

                    // Set success message
                    TempData["SuccessMessage"] = "Update is Successfully";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnergyUsageExists(energyUsage.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                // Redirect to the Index action
                return RedirectToAction(nameof(Index));
            }
            return View(energyUsage);
        }

        // GET: EnergyUsage/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var energyUsage = await _context.EnergyUsages
                .FirstOrDefaultAsync(m => m.Id == id);
            if (energyUsage == null)
            {
                return NotFound();
            }
            return View(energyUsage);
        }

        // POST: EnergyUsage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var energyUsage = await _context.EnergyUsages.FindAsync(id);
            _context.EnergyUsages.Remove(energyUsage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnergyUsageExists(int id)
        {
            return _context.EnergyUsages.Any(e => e.Id == id);
        }

        // GET: EnergyUsage/RealTimeData
        [HttpGet]
        public async Task<IActionResult> RealTimeData()
        {
            // Fetch real-time data from the database
            var energyUsages = await _context.EnergyUsages
                .OrderByDescending(e => e.Timestamp) // Fetch the latest data
                .Take(10) // Get the most recent records
                .ToListAsync();

            // Prepare the data to return as JSON
            var data = energyUsages.Select(e => new
            {   e.UserName,
                e.Timestamp,
                e.Location,
                e.Consumption
            });

            return Json(data);
        }

        // GET: EnergyUsage/HistoricalData
        public async Task<IActionResult> HistoricalData()
        {
            // Fetch historical data from the database
            var energyUsages = await _context.EnergyUsages
                .OrderByDescending(e => e.Timestamp) // Order by most recent data
                .ToListAsync(); // Get all data

            // Pass the data to the view
            return View(energyUsages);
        }
    }
}
