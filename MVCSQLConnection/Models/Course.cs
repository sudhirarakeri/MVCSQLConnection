using System.ComponentModel.DataAnnotations;

namespace MVCSQLConnection.Models
{
    public class Course
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Fees { get; set; }
    }
}
