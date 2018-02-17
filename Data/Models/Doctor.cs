using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace P01_HospitalDatabase.Data.Models
{
    public class Doctor
    {
        public Doctor()
        {

        }
        [Key]
        public int DoctorId { get; set; }

        [Required(ErrorMessage = "Doctor's name is a required field!")]
        [MinLength(2, ErrorMessage = "Name must be from 2 to 120 chars long!")]
        [MaxLength(120, ErrorMessage = "Name must be from 2 to 120 chars long!")]
        public string Name { get; set; }

        [MinLength(2, ErrorMessage = "Speciality must be at least 2 chars long!")]
        public string Specialty { get; set; }

        public int VisitationId { get; set; }
        public Visitation Visitation { get; set; }


        public HashSet<Visitation> Visitations { get; set; } = new HashSet<Visitation>();
    }
}
