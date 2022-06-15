using Core.Interface;

namespace Core.Entities
{
    public class BaseEntity
    {
        private DateTime _defaultDate = DateTime.Now;
        public int Id { get; set; }        
        public int CreatedByUserId { get; set; }       
        public DateTime CreatedDate { get { return _defaultDate; } set { _defaultDate = value == null ? DateTime.Now : value; } }
        public int? UpdatedByUserId { get; set; }       
        public DateTime? UpdatedDate { get; set; }
    }
}