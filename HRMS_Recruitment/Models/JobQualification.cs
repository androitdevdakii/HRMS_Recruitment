namespace HRMS_Recruitment.Models
{
    public class JobQualification
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public IEnumerable<JobPosition>? Positions { get; set; } = [];

    }
}
