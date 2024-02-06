using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;

namespace RightPath.Models
{
    public interface IProduct
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string Logo { get; set; }
        public int Lecture1Id { get; set; }
    }
}
