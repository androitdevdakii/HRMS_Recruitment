using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HRMS_Recruitment.Data;
using HRMS_Recruitment.Models;

namespace HRMS_Recruitment.Controllers
{
    public class JobPositionVacanciesController : Controller
    {
        private readonly HRMS_RecruitmentContext _context;

        public JobPositionVacanciesController(HRMS_RecruitmentContext context)
        {
            _context = context;
        }

        // GET: JobPositionVacancies
        public async Task<IActionResult> Index()
        {
            var hRMS_RecruitmentContext = _context.JobPositionVacancy.Include(j => j.JobPosition);
            return View(await hRMS_RecruitmentContext.ToListAsync());
        }

        // GET: JobPositionVacancies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobPositionVacancy = await _context.JobPositionVacancy
                .Include(j => j.JobPosition)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jobPositionVacancy == null)
            {
                return NotFound();
            }

            return View(jobPositionVacancy);
        }

        // GET: JobPositionVacancies/Create
        public IActionResult Create()
        {
            //ViewData["JobPositionId"] = new SelectList(_context.JobPosition, "Id", "Id");

            ViewData["JobPositionTitles"] = _context.JobPosition
                .Select(jp => new SelectListItem
                {
                    Value = jp.Id.ToString(),
                    Text = jp.Title
                }).ToList();
            return View();
        }

        // POST: JobPositionVacancies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IsHrApproved,IsDirApproved,IsPostedOnWebsite,PostingDate,ClosingDate,JobPositionId")] JobPositionVacancy jobPositionVacancy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jobPositionVacancy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["JobPositionId"] = new SelectList(_context.JobPosition, "Id", "Id", jobPositionVacancy.JobPositionId);
            return View(jobPositionVacancy);
        }

        // GET: JobPositionVacancies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobPositionVacancy = await _context.JobPositionVacancy.FindAsync(id);
            if (jobPositionVacancy == null)
            {
                return NotFound();
            }
            ViewData["JobPositionId"] = new SelectList(_context.JobPosition, "Id", "Id", jobPositionVacancy.JobPositionId);
            ViewData["JobPositionTitles"] = _context.JobPosition
                .Select(jp => new SelectListItem
                {
                    Value = jp.Id.ToString(),
                    Text = jp.Title
                }).ToList();
            return View(jobPositionVacancy);
        }

        // POST: JobPositionVacancies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IsHrApproved,IsDirApproved,IsPostedOnWebsite,PostingDate,ClosingDate,JobPositionId")] JobPositionVacancy jobPositionVacancy)
        {
            if (id != jobPositionVacancy.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jobPositionVacancy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobPositionVacancyExists(jobPositionVacancy.Id))
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
            ViewData["JobPositionId"] = new SelectList(_context.JobPosition, "Id", "Id", jobPositionVacancy.JobPositionId);
            return View(jobPositionVacancy);
        }

        // GET: JobPositionVacancies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobPositionVacancy = await _context.JobPositionVacancy
                .Include(j => j.JobPosition)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jobPositionVacancy == null)
            {
                return NotFound();
            }

            return View(jobPositionVacancy);
        }

        // POST: JobPositionVacancies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jobPositionVacancy = await _context.JobPositionVacancy.FindAsync(id);
            if (jobPositionVacancy != null)
            {
                _context.JobPositionVacancy.Remove(jobPositionVacancy);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JobPositionVacancyExists(int id)
        {
            return _context.JobPositionVacancy.Any(e => e.Id == id);
        }
    }
}
