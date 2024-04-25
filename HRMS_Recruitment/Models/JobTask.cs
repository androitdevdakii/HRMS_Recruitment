namespace HRMS_Recruitment.Models
{
    public class JobTask
    {
        public int Id { get; set; }
        public string? Desccription { get; set; }
        public string? Type { get; set; }
        public IEnumerable<JobPosition>? JobPositions { get; } = [];
    }
}

