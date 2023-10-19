using System.ComponentModel.DataAnnotations;

namespace VarsityDatabase.Models
{
    public class StudentModel
    {
        [Required] [Key] public int Student_ID { get; set; }
        public string Student_Name { get; set; }
        public string Student_Surname { get; set; }
        public string Student_Email { get; set; }
        public int Student_Year { get; set; }
        public string Student_ZipCode { get; set; }

    }
}
