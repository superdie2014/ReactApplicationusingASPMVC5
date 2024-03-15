using System.ComponentModel.DataAnnotations;

namespace ReactApplicationusingASPMVC5.Server.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        [Required]
        public string? StudentName { get; set; }

        [Range(10, 100)]
        public int Age { get; set; }
    }
}
