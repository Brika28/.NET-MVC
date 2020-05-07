using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }

        [Required(ErrorMessage = "Naziv tečaja je obavezan!")]
        [StringLength(150, MinimumLength = 3)]
        [Display(Name = "Naziv tečaja")]
        public string CourseName { get; set; }

        [Required(ErrorMessage ="Opis je obavezan!")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Opis")]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Datum")]
        public DateTime Date { get; set; }

        [Display(Name = "Zauzet")]
        public bool Full { get; set; }

        
        public ICollection<Booking> Booking { get; set; }
    }
}
