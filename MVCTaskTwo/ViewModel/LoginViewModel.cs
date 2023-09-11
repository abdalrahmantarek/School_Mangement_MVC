using System.ComponentModel.DataAnnotations;

namespace MVCTaskTwo.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; } = null!;

        [Display(Name="Rememper Me")]
        public bool Ispersisite { get; set; }

    }
}
