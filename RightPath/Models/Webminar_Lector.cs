namespace RightPath.Models
{
    public class Webminar_Lector
    {
        public int WebminarId { get; set; }

        public Webminar Webminar { get; set; }

        public int LectureId { get; set; }

        public Lecture Lecture { get; set; }
    }
}
