using System.ComponentModel.DataAnnotations;

namespace CerZen.Authorization.Accounts.Dto
{
    public class SendEmailActivationLinkInput
    {
        [Required]
        public string EmailAddress { get; set; }
    }
}