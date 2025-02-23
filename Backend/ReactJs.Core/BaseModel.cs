using System.ComponentModel.DataAnnotations;

namespace ReactJs.Core
{
    public class BaseModel<T>
    {
        [Key]
        public T Id { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
