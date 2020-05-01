using System.ComponentModel.DataAnnotations;

namespace CourseLibrary.API.Models
{
    public class CourseForUpdateDto : CourseForManipulationDto
    {
        [Required(ErrorMessage = "Preencha a descrição")]
        public override string Description
        {
            get => base.Description;
            set => base.Description = value;
        }
    }
}