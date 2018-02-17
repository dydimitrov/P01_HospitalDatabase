using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace P01_HospitalDatabase.Data.Models
{
    public class Diagnose
    {
        public Diagnose()
        {

        }
        [Key]
        public int DiagnoseId { get; set; }

        [Required(ErrorMessage = "A diagnose name is required!")]
        public string Name { get; set; }

        public string Comments { get; set; }

        public int PatientId { get; set; }
        public Patient Patient { get; set; }


    }
}
