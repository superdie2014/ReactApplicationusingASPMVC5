using System.ComponentModel.DataAnnotations;

namespace ReactAppMVCclient.Models
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
