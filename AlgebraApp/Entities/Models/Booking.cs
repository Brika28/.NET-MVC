using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }

        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name ="Datum rezervacije")]
        public DateTime DateOfBooking { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 2)]
        [Display(Name ="Ime")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 2)]
        [Display(Name ="Prezime")]
        public string LastName { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 2)]
        [Display(Name ="Adresa")]
        public string Address { get; set; }

        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 5)]
        [Display(Name ="Broj telefona")]
        public string Phone { get; set; }

        [Display(Name ="Status upisa")]
        public string Status { get; set; }


        public int CourseId { get; set; }
        
        public Course Course { get; set; }


    }
}
