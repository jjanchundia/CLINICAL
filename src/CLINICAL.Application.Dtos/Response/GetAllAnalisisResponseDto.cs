
namespace CLINICAL.Application.Dtos.Response
{
    public class GetAllAnalisisResponseDto
    {
        public int AnalisisId { get; set; }
        public string? Name { get; set; }
        public int State { get; set; }
        public DateTime AuditCreateDate { get; set; }
        public string? StateAnalisis { get; set; }
    }
}