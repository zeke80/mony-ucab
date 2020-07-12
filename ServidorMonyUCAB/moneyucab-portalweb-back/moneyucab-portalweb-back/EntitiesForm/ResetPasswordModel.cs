using System.ComponentModel.DataAnnotations;

namespace moneyucab_portalweb_back.EntitiesForm
{
    public class ResetPasswordModel
    {
        [Required]
        public string idUsuario { get; set; }
        [Required]
        public string resetPasswordToken { get; set; }
        [Required]
        public string newPassword { get; set; }
    }
}
