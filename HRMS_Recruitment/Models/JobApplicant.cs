using System.ComponentModel.DataAnnotations;

namespace HRMS_Recruitment.Models
{
    public class JobApplicant
    {
        public int Id { get; set; }

        public string? Prefix { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public string? Email { get; set; }

        public string? NIN { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }
        
        public int GenderId { get; set; }

        public Gender? Gender { get; set; }

        public string? MaritalStatus { get; set; }

        public string? PlaceOfResidence { get; set; }

        public int OverallExperience {  get; set; }

        public IEnumerable<JobQualification> JobQualifications { get; set; } = [];

        public IEnumerable<JobEducation> JobEducations { get; set; } = [];

        public IEnumerable<JobExperience> JobExperiences { get; set; } = [];

    }
}
