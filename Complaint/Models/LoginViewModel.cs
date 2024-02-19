using System.ComponentModel.DataAnnotations;

namespace Complaint.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "กรุณากรอกรหัสพนักงาน")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "กรุณากรอกรหัสผ่าน")]
        public string Password { get; set; }
        public string CardID { get; set; }
        public bool RememberMe { get; internal set; }
    }
}
