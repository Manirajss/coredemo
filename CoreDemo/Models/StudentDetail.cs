using System;
using System.Collections.Generic;

#nullable disable

namespace CoreDemo.Models
{
    public partial class StudentDetail
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int? Age { get; set; }
    }
}
