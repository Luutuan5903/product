using System.ComponentModel.DataAnnotations;

namespace FinallyProject.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}