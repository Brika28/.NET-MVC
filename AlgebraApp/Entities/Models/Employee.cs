using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace Entities
{
    public class Employee
    {
        [Key]
        public int EmpolyeeId { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 2)]
        [Display(Name ="Ime")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 2)]
        [Display(Name ="Prezime")]
        public string LastName { get; set; }

        
        [StringLength(150, MinimumLength = 5)]
        [Display(Name ="Korisničko ime")]
        public string UserName { get; set; }


    }
}
