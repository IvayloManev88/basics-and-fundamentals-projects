using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static P01_HospitalDatabase.Common.EntityValidationConstants.Diagnose;

namespace P01_HospitalDatabase.Data.Models
{
    public class Diagnose
    {
        [Key]
        public int DiagnoseId { get; set; }
        [Unicode(true)]
        [MaxLength(DiagnoseNameMaxLength)]
        public string Name { get; set; } = null!;

        [Unicode(true)]
        [MaxLength(DiagnoseCommentMaxLength)]
        public string? Comments { get; set; }
        [ForeignKey(nameof(Patient))]
        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; } = null!;

    }
}
