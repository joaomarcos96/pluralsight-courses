using System.ComponentModel.DataAnnotations;
using CourseLibrary.API.ValidationAttributes;

namespace CourseLibrary.API.Models
{
    [CourseTitleMustBeDifferentFromDescription(
        ErrorMessage = "Título deve ser diferente da descrição")]
    public class CourseForCreationDto //: IValidatableObject
    {
        [Required(ErrorMessage = "O campo title é obrigatório")]
        [MaxLength(100, ErrorMessage = "O título deve conter no máximo 100 caracteres")]
        public string Title { get; set; }

        [MaxLength(1500)]
        public string Description { get; set; }

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