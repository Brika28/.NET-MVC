using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Employee
    {
        [Key]
        public int EmpolyeeId { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 2)]
        public string LastName { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 5)]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
