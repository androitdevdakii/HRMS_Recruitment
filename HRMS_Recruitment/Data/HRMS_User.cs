using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace HRMS_Recruitment.Data
{
    public class HRMS_User : IdentityUser
    {
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }  = string.Empty;

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; } = string.Empty;

    }
}
