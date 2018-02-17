using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace P01_HospitalDatabase.Data.Models
{
    public class Medicament
    {
        public Medicament()
        {

        }
        [Key]
        public int MedicamentId { get; set; }

        [Required(ErrorMessage = "Medicament name is required!")]
        public string Name { get; set; }

        public HashSet<PatientMedicament> Prescriptions { get; set; } = new HashSet<PatientMedicament>();
    }
}
