using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProductShop.DTOs.Export
{
    [XmlType("Category")]
    public class ExportCategoriesDto
    {
        [XmlElement("name")]
        public string Name { get; set; } = null!;

        [XmlElement("count")]
        public string Count { get; set; } = null!;

        [XmlElement("averagePrice")]
        public string AveragePrice { get; set; } = null!;

        [XmlElement("totalRevenue")]
        public string TotalRevenue { get; set; } = null!;
    }
}
