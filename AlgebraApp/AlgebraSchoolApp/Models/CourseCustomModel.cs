using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AlgebraSchoolApp.Models
{
    public class CourseCustomModel
    {
        public int CourseId { get; set; }
        [DisplayName("Naziv tečaja")]
        public string CourseName { get; set; }
        [DisplayName("Opis")]
        public string Description { get; set; }
        [DisplayName("Datum početka")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [DisplayName("Popunjen")]
        public bool Full { get; set; }
        [DisplayName("Broj polaznika")]
        public int BookingCount { get; set; }
    }
}