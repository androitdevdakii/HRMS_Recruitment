namespace HRMS_Recruitment.Models
{
    public class JobPosition
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; } = null;
        public int JobDepartmentId { get; set; }
        public JobDepartment? Department { get; set; }
        public IEnumerable<JobTask>? JobTasks { get; } = [];
    }
}
