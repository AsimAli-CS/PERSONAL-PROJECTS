using System;
using System.Collections.Generic;

namespace ProjectStudentSystem.Models
{
    public partial class Activity
    {
        public int Id { get; set; }
        public string Activity1 { get; set; } = null!;
        public DateTime CreateDate { get; set; }
    }
}
