using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MvcMovie.Models
{
    public class ApplicationUser: IdentityUser
    {
        [Display(Name = "Display Name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

    }
}
