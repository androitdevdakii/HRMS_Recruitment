namespace HRMS_Recruitment.Models
{
    public class JobDepartment
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public IEnumerable<JobPosition>? Positions { get; set; }
        
    }
}
