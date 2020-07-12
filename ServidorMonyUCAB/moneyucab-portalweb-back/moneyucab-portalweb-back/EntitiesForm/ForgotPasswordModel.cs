using System.ComponentModel.DataAnnotations;

namespace moneyucab_portalweb_back.EntitiesForm
{
    public class ForgotPasswordModel
    {
        [Required]
        [EmailAddress]
        public string email { get; set; }
    }
}
