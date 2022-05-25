using System.Text.Json.Serialization;

namespace Core.Entities
{
    public class EmployeeAddress: BaseEntity
    {
        public int EmployeeId { get; set; }
        [JsonIgnore]
        public Employee Employee { get; set; }
        public string Address1 { get; set; }
        public string Barangay { get; set; }
        public string Municipality { get; set; }
        public string Province { get; set; }
    }
}