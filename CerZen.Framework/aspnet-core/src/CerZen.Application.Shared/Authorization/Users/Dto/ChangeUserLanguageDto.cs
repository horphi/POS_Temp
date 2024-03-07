using System.ComponentModel.DataAnnotations;

namespace CerZen.Authorization.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}
