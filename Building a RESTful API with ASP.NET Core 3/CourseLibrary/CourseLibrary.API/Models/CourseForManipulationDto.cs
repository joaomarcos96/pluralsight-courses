using System.ComponentModel.DataAnnotations;
using CourseLibrary.API.ValidationAttributes;

namespace CourseLibrary.API.Models
{
    [CourseTitleMustBeDifferentFromDescription(
            ErrorMessage = "Título deve ser diferente da descrição")]
    public abstract class CourseForManipulationDto
    {
        [Required(ErrorMessage = "O campo title é obrigatório")]
        [MaxLength(100, ErrorMessage = "O título deve conter no máximo 100 caracteres")]
        public string Title { get; set; }

        [MaxLength(1500, ErrorMessage = "A descrição deve conter no máximo 1500 caracteres")]
        public virtual string Description { get; set; }
    }
}