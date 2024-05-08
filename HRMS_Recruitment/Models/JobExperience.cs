using System.ComponentModel.DataAnnotations;

namespace HRMS_Recruitment.Models
{
    public class JobExperience
    {
        public int Id { get; set; }
        public string? Employer { get; set; }
        public string? JobTitle { get; set; }
        public string? Achievements { get; set;}

        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }
        public int JobApplicantId { get; set; }

        public JobApplicant? JobApplicant { get; set; }
    }
}