using System.ComponentModel.DataAnnotations;

namespace HRMS_Recruitment.Models
{
    public class JobEducation
    {
        public int Id { get; set; }
        public string? Insitute { get; set; }
        public string? Program { get; set; }
        public string? Level { get; set; }
        public decimal? CGPA { get; set; }
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? GraduationDate { get; set; }
        public IEnumerable<JobApplicant> JobApplicants { get; set; } = [];
    }
}