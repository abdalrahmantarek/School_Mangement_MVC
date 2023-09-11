using System.ComponentModel.DataAnnotations;

namespace MVCTaskTwo.ViewModel
{
    public class RegistrationViewModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;

        [Required]
        [DataType(DataType.Text)]
        public string UesrName { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and compair passwrd are not matched")]
        public string ConfirmPassword { get; set; } = null!;

    }
}
