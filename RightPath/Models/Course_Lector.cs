using Microsoft.EntityFrameworkCore;

namespace RightPath.Models
{
    public class Course_Lector
    {
        public int CourseId { get; set; }
        public Course Course { get; set; }

        public int LectureId { get; set; }
        public Lecture Lecture { get; set; }

    }
}
