using System.Xml.Linq;

namespace CLINICAL.Domain.Entities
{
    public class Analisis
    {
        public int AnalisisId { get; set; }
        public string? Name { get; set; }
        public int State { get; set; }
        public DateTime AuditCreateDate { get; set; }
    }
}