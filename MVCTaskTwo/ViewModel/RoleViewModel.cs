using Microsoft.Build.Framework;

namespace MVCTaskTwo.ViewModel
{
    public class RoleViewModel
    {
        [Required]
        public string RoleName { get; set; } = null!;
    }
}
