using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CarDealer.DTOs.Import
{
    [XmlType("Sale")]
    public class ImportSaleDto
    {
        [XmlElement("carId")]
        [Required]
        public string CarId { get; set; } = null!;

        [XmlElement("customerId")]
        [Required]
        public string CustomerId { get; set; } = null!;

        [XmlElement("discount")]
        [Required]
        public string Discount { get; set; } = null!;


       
    }
}
