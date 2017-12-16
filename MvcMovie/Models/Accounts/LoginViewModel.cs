using System.ComponentModel.DataAnnotations;


namespace MvcMovie.Models.Accounts
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string NewScreenName { get; set; }

        public bool RememberMe { get; set; }
    }
}
