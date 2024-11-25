using System.ComponentModel.DataAnnotations;

namespace StudentManagementWithLogin.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@(gmail\.com|yahoo\.com)$",
            ErrorMessage = "Email must end with @gmail.com or @yahoo.com.")]
        public string Email { get; set; }
    }

}
