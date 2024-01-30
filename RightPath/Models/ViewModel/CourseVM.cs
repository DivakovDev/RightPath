using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using RightPath.Models;

namespace RightPath.Models.ViewModel
{
    public class CourseVM
    {
        public Course Course { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> LectureList { get; set; }

    }
}
