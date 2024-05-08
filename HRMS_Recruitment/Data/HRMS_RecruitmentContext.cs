using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HRMS_Recruitment.Models;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace HRMS_Recruitment.Data
{
    public class HRMS_RecruitmentContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public HRMS_RecruitmentContext (DbContextOptions<HRMS_RecruitmentContext> options)
            : base(options)
        {
        }

        public DbSet<HRMS_Recruitment.Models.JobPosition> JobPosition { get; set; } = default!;
        public DbSet<HRMS_Recruitment.Models.JobDepartment> JobDepartment { get; set; } = default!;
        public DbSet<HRMS_Recruitment.Models.JobPositionVacancy> JobPositionVacancy { get; set; } = default!;
        public DbSet<HRMS_Recruitment.Models.JobApplication> JobApplication { get; set; } = default!;
        public DbSet<HRMS_Recruitment.Models.JobApplicant> JobApplicant { get; set; } = default!;
    }
}
