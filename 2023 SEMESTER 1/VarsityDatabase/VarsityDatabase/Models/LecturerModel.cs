using System.ComponentModel.DataAnnotations;

namespace VarsityDatabase.Models
{
    public class LecturerModel
    {
        [Required] [Key] public int Lecturer_ID { get; set; }
        public string Lecturer_Name { get; set; }
        public string Lecturer_Surname  { get; set; }

        public string Lecturer_Email { get; set; }  
        public string Lecturer_Module { get; set; }

    }
}
