using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMovie.Models
{
    public class RenameViewModel
    {
        [Display(Name = "Display Name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
    }
}
