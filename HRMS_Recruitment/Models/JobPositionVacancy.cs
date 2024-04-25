using System.ComponentModel.DataAnnotations;

namespace HRMS_Recruitment.Models
{
    public class JobPositionVacancy
    {
        public int Id { get; set; }
        public bool IsHrApproved { get; set; }
        public bool IsDirApproved { get; set; }
        public bool IsPostedOnWebsite { get; set; }
        [DataType(DataType.Date)]
        public DateTime? PostingDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? ClosingDate { get; set; }
        public int JobPositionId { get; set; }
        public JobPosition? JobPosition { get; set; }

    }
}
