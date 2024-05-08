using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HRMS_Recruitment.Data;
using HRMS_Recruitment.Models;
using Microsoft.AspNetCore.Authorization;

namespace HRMS_Recruitment.Controllers
{
    public class JobDepartmentsController : Controller
    {
        private readonly HRMS_RecruitmentContext _context;

        public JobDepartmentsController(HRMS_RecruitmentContext context)
        {
            _context = context;
        }

        // GET: JobDepartments
        public async Task<IActionResult> Index()
        {
            return View(await _context.JobDepartment.ToListAsync());
        }

        // GET: JobDepartments/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobDepartment = await _context.JobDepartment
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jobDepartment == null)
            {
                return NotFound();
            }

            return View(jobDepartment);
        }

        // GET: JobDepartments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: JobDepartments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] JobDepartment jobDepartment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jobDepartment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jobDepartment);
        }

        // GET: JobDepartments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobDepartment = await _context.JobDepartment.FindAsync(id);
            if (jobDepartment == null)
            {
                return NotFound();
            }
            return View(jobDepartment);
        }

        // POST: JobDepartments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] JobDepartment jobDepartment)
        {
            if (id != jobDepartment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jobDepartment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobDepartmentExists(jobDepartment.Id))
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
            return View(jobDepartment);
        }

        // GET: JobDepartments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobDepartment = await _context.JobDepartment
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jobDepartment == null)
            {
                return NotFound();
            }

            return View(jobDepartment);
        }

        // POST: JobDepartments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jobDepartment = await _context.JobDepartment.FindAsync(id);
            if (jobDepartment != null)
            {
                _context.JobDepartment.Remove(jobDepartment);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JobDepartmentExists(int id)
        {
            return _context.JobDepartment.Any(e => e.Id == id);
        }
    }
}
