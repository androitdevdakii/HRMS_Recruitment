using System.ComponentModel.DataAnnotations;

namespace HRMS_Recruitment.Models
{
    public class JobApplication
    {
        public JobPositionVacancy JobVacancy { get; set; }
        public int Id { get; set; }
        public string? Name { get; set; }
        
        //[Required(ErrorMessage = "Please enter your email")]
        //[EmailAddress(ErrorMessage = "Invalid Email entered")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please upload your cv")]
        public Byte [] CvFile { get; set; }
        public string CvName { get; set; }
        public int JobPositionVacancyId;

    }
}
