using System;
using System.Collections.Generic;

namespace ProjectStudentSystem.Models
{
    public partial class AddStudent
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string RollNo { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public string City { get; set; } = null!;
        public string Interest { get; set; } = null!;
        public string Department { get; set; } = null!;
        public string DegreeTitle { get; set; } = null!;
        public string Subject { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

    }
}
