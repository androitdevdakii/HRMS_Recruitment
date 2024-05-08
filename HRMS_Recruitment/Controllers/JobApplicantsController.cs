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
    public class JobApplicantsController : Controller
    {
        private readonly HRMS_RecruitmentContext _context;

        public JobApplicantsController(HRMS_RecruitmentContext context)
        {
            _context = context;
        }

        // GET: JobApplicants
        public async Task<IActionResult> Index()
        {
            var hRMS_RecruitmentContext = _context.JobApplicant.Include(j => j.Gender);
            return View(await hRMS_RecruitmentContext.ToListAsync());
        }

        // GET: JobApplicants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobApplicant = await _context.JobApplicant
                .Include(j => j.Gender)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jobApplicant == null)
            {
                return NotFound();
            }

            return View(jobApplicant);
        }

        // GET: JobApplicants/Create
        public IActionResult Create()
        {
            ViewData["GenderId"] = new SelectList(_context.Set<Gender>(), "Id", "Id");
            return View();
        }

        // POST: JobApplicants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Prefix,FirstName,LastName,Email,NIN,DateOfBirth,GenderId,MaritalStatus,PlaceOfResidence,OverallExperience")] JobApplicant jobApplicant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jobApplicant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GenderId"] = new SelectList(_context.Set<Gender>(), "Id", "Id", jobApplicant.GenderId);
            return View(jobApplicant);
        }

        // GET: JobApplicants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobApplicant = await _context.JobApplicant.FindAsync(id);
            if (jobApplicant == null)
            {
                return NotFound();
            }
            ViewData["GenderId"] = new SelectList(_context.Set<Gender>(), "Id", "Id", jobApplicant.GenderId);
            return View(jobApplicant);
        }

        // POST: JobApplicants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Prefix,FirstName,LastName,Email,NIN,DateOfBirth,GenderId,MaritalStatus,PlaceOfResidence,OverallExperience")] JobApplicant jobApplicant)
        {
            if (id != jobApplicant.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jobApplicant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobApplicantExists(jobApplicant.Id))
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
            ViewData["GenderId"] = new SelectList(_context.Set<Gender>(), "Id", "Id", jobApplicant.GenderId);
            return View(jobApplicant);
        }

        // GET: JobApplicants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobApplicant = await _context.JobApplicant
                .Include(j => j.Gender)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jobApplicant == null)
            {
                return NotFound();
            }

            return View(jobApplicant);
        }

        // POST: JobApplicants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jobApplicant = await _context.JobApplicant.FindAsync(id);
            if (jobApplicant != null)
            {
                _context.JobApplicant.Remove(jobApplicant);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JobApplicantExists(int id)
        {
            return _context.JobApplicant.Any(e => e.Id == id);
        }
    }
}
