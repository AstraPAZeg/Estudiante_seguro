

namespace APIStudentSecurity.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Student
    {
        [Key]
        public int StudentID { get; set; }

        [StringLength(30)]
        [Required(ErrorMessage = "This field is mandatory {0}")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "This field is mandatory {0}")]
        [StringLength(30, ErrorMessage = "This field must contain between {2} and {1} characters", MinimumLength = 2)]
        public string FirstName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EnrollmentDate { get; set; }

    }
}