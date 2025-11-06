using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProductShop.DTOs.Export
{
    [XmlType("Users")]
    public class ExportUserDto
    {
        [XmlElement("count")]
        public string Count { get; set; } = null!;

        [XmlArray("users")]
        [XmlArrayItem("User")]
        public ExportUsersWithProductsDto[] Users { get; set; } = null!;
    }
}
