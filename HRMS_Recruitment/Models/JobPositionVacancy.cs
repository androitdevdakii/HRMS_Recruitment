using System.ComponentModel.DataAnnotations;

namespace HRMS_Recruitment.Models
{
    public class JobPositionVacancy
    {
        public int Id { get; set; }
        [Display(Name ="Submitted For Apporval")]
        public bool IsSubmittedToHrForApproval { get; set; }
        public bool IsSubmittedToDirForApproval { get; set; }
        public bool IsHrApproved { get; set; }
        public bool IsDirApproved { get; set; }
        [Display(Name = "Posted on Website")]
        public bool IsPostedOnWebsite { get; set; }
        [DataType(DataType.Date)]
        public DateTime? PostingDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? ClosingDate { get; set; }
        public int JobPositionId { get; set; }
        [Display(Name = "Job Title")]
        public JobPosition? JobPosition { get; set; }
    }
}
