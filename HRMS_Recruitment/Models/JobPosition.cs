namespace HRMS_Recruitment.Models
{
    public class JobPosition
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; } = null;
        public IEnumerable<JobTask>? JobTasks { get; } = [];

    }
}
