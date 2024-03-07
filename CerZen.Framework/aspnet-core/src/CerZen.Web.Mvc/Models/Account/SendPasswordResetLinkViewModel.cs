using System.ComponentModel.DataAnnotations;

namespace CerZen.Web.Models.Account
{
    public class SendPasswordResetLinkViewModel
    {
        [Required]
        public string EmailAddress { get; set; }
    }
}