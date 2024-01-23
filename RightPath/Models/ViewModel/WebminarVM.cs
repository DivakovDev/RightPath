using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RightPath.Models.ViewModel
{
    public class WebminarVM
    {
        public Webminar Webminar { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> CityList { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> LectureList { get; set; }

    }
}
