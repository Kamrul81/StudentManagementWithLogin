using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace StudentManagementWithLogin.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@(gmail\.com|yahoo\.com)$",
            ErrorMessage = "Email must end with @gmail.com or @yahoo.com.")]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^(017|015|013|014|016|018|019)\d{8}$",
            ErrorMessage = "Mobile number must start with 013, 014, 015, 016, 017, 018 or 019 and be exactly 11 digits long.")]
        public string Mobile { get; set; }

        [Required]
        public string Address { get; set; }

    }
}
