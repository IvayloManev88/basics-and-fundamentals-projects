using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static P01_HospitalDatabase.Common.EntityValidationConstants.Medicament;

namespace P01_HospitalDatabase.Data.Models
{
    public class Medicament
    {
        [Key]
        public int MedicamentId { get; set; }
        [Unicode(true)]
        [MaxLength(MedicamentNameMaxLength)]
        public string Name { get; set; } = null!;

        public ICollection<PatientMedicament> Prescriptions { get; set; } = new HashSet<PatientMedicament>();
    }
}
