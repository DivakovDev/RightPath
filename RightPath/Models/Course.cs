﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RightPath.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Името е задължително!")]
        [DisplayName("Име на Курса")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Описанието е задължително!")]
        [DisplayName("Описание на Курса")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Времетраенето задължително трябва да бъде в часове!")]
        [DisplayName("Времетраене на Курса")]
        public double Duration { get; set; }

        [Required(ErrorMessage = "Корицата е задължителна!")]
        [DisplayName("Корица на Курса")]
        [ValidateNever]
        public string Logo { get; set; }
        [DisplayName("Лектор")]
        public int LectureId { get; set; }
        [ForeignKey("LectureId")]
        [ValidateNever]
        public Lecture Lecture { get; set; }

        public List<ShoppingCart> Carts { get; set; } = new List<ShoppingCart>();


    }
}
