using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace P01_HospitalDatabase.Data.Models
{
    public class Patient
    {
        public Patient()
        {

        }
        [Key]
        public int PatientId { get; set; }

        [MinLength(2, ErrorMessage = "First Name must be between 2 and 120 characters")]
        [MaxLength(120, ErrorMessage = "First Name must be between 2 and 120 characters")]
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }

        [MinLength(2, ErrorMessage = "Last Name must be between 2 and 120 characters")]
        [MaxLength(120, ErrorMessage = "Last Name must be between 2 and 120 characters")]
        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }

        public string Address { get; set; }

        [RegularExpression(@"^([A-Za-z0-9]+)([\w\.\-]*)([A-Za-z0-9]+)@([[A-Za-z0-9]+(\-*[A-Za-z0-9])*)((\.([A-Za-z0-9]){2,3})+)$")]
        [Required]
        public string Email { get; set; }

        [Required(ErrorMessage = "You must specify if the patient is insured")]
        public bool HasInsurance { get; set; }

        public int DiagnoseId { get; set; }
        public Diagnose Diagnose { get; set; }

        public int VisitationId { get; set; }
        public Visitation Visitation { get; set; }

        public int PatientMedicamentId { get; set; }
        public PatientMedicament PatientMedicaments { get; set; }

        public ICollection<Diagnose> Diagnoses { get; set; } = new List<Diagnose>();
        public ICollection<Visitation> Visitations { get; set; } = new List<Visitation>();
        public ICollection<PatientMedicament> Prescriptions { get; set; } = new List<PatientMedicament>();
    }
}
