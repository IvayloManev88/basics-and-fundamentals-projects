using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using static P01_HospitalDatabase.Common.EntityValidationConstants.Patient;

namespace P01_HospitalDatabase.Data.Models
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }
        [Unicode(true)]
        [MaxLength(FirstNameMaxLength)]
        public string FirstName { get; set; } = null!;

        [Unicode(true)]
        [MaxLength(LastNameMaxLength)]
        public string LastName { get; set; } = null!;

        [Unicode(true)]
        [MaxLength(PatientAddressLength)]
        public string Address  { get; set; } = null!;

        [Unicode(false)]
        [MaxLength(PatientEmailLength)]
        public string Email  { get; set; } = null!;

        public bool HasInsurance { get; set; }

        public virtual ICollection<Visitation> Visitations { get; set; } = new HashSet<Visitation>();
        public virtual ICollection<Diagnose> Diagnoses { get; set; } = new HashSet<Diagnose>();
        public virtual ICollection<PatientMedicament> Prescriptions { get; set; } = new HashSet<PatientMedicament>();
    }
}
