namespace RightPath.Models.ViewModel
{
    public class HomeViewModel
    {
        public IEnumerable<Webminar> Webminars { get; set; }
        public IEnumerable<Course> Courses { get; set; }
        public IEnumerable<Lecture> Lectures { get; set; }

        public HomeViewModel()
        {
            Webminars = new List<Webminar>();
            Courses = new List<Course>();
            Lectures = new List<Lecture>();
        }
    }
}
