using CourseLibrary.API.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CourseLibrary.API.Models
{
    [CourseTitleMustBeDifferentFromDescriptionAttribute 
        (ErrorMessage ="Title & Descr must be different")]
    public class CourseForCreationDto //:IValidatableObject // only fires if all other validations succeed
    {
        [Required(ErrorMessage ="Title Required")]
        [MaxLength(100,ErrorMessage ="100 Char only")]
        public string Title { get; set; }

        [MaxLength(500, ErrorMessage = "500 Char only")]
        public string Description { get; set; }

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    if (Title == Description)
        //    {
        //        yield return new ValidationResult(
        //            "The provided description should be different from the title",
        //            new[] { "CourseForCreationDto" });
        //    }
        //}
    }
}
