using Microsoft.AspNetCore.Identity;


namespace MvcMovie.Models.Accounts
{
    public class ApplicationUser: IdentityUser
    {
       
        public string ScreenName { get; set; }

    }
}
