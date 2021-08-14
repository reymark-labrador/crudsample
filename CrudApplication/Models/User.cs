using System.ComponentModel.DataAnnotations;

namespace CrudApplication.Models
{
    public class User
    {
        public int ID { get; set; }
        [Required]
        public int DepartmentID { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
