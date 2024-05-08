using System.ComponentModel.DataAnnotations;

namespace HRMS_Recruitment.Models
{
    public class JobQualification
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? Number { get; set; }

        [DataType(DataType.Date)]
        public DateTime? IssueDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ExpirationDate { get; set; }

        public IEnumerable<JobPosition>? Positions { get; set; } = [];

        public IEnumerable<JobQualification> Qualifications { get; set; } = [];

        public IEnumerable<JobApplicant> Applicants { get; set; } = [];

    }
}
