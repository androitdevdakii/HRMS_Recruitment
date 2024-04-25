using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HRMS_Recruitment.Models;

namespace HRMS_Recruitment.Data
{
    public class HRMS_RecruitmentContext : DbContext
    {
        public HRMS_RecruitmentContext (DbContextOptions<HRMS_RecruitmentContext> options)
            : base(options)
        {
        }

        public DbSet<HRMS_Recruitment.Models.JobPosition> JobPosition { get; set; } = default!;
    }
}
