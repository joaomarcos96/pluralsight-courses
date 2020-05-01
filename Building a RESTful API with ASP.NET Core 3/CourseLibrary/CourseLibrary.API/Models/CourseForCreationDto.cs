using System.ComponentModel.DataAnnotations;
using CourseLibrary.API.ValidationAttributes;

namespace CourseLibrary.API.Models
{
    public class CourseForCreationDto : CourseForManipulationDto// IValidatableObject
    {
        // IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        // {
        //     if (Title == Description)
        //     {
        //         yield return new ValidationResult("The provided description should be different from the title.",
        //             new[] { nameof(CourseForCreationDto) });
        //     }
        // }
    }
}