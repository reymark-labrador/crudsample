using System.ComponentModel.DataAnnotations;

namespace CrudApplication.Models
{
    public class Department
    {
        public int ID { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
