using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static P01_HospitalDatabase.Common.EntityValidationConstants.Doctor;

namespace P01_HospitalDatabase.Data.Models
{
    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }
        [Unicode(true)]
        [MaxLength(DoctorNameMaxLength)]
        public string Name { get; set; } = null!;

        [Unicode(true)]
        [MaxLength(DoctorSpecialtyMaxLength)]
        public string Specialty { get; set; } = null!;

        public virtual ICollection<Visitation> Visitations { get; set; }= new HashSet<Visitation>();    
    }
}
