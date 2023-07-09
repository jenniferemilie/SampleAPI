using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApi.Models
{
    public class ProfessorDTOV2
    {
        public int Professor_ID { get; set; }
        public string Professor_Surname { get; set; }
        public string Section_Name { get; set; }
        public int Professor_Office { get; set; }
        public string Professor_Email { get; set; }
        public IEnumerable<CourseDTO> CourseList { get; set; } 
    }
}
