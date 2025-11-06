using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProductShop.DTOs.Export
{
    [XmlType("SoldProducts")]
    public class ExportSoldProductsArray
    {
        [XmlElement("count")]
        public string Count { get; set; } = null!;

        [XmlArray("products")]
        [XmlArrayItem("Product")]
        public ExportSoldProductsDto[] Products { get; set; } = null!;
    }
}
