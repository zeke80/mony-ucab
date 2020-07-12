using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace moneyucab_portalweb_back.EntitiesForm
{
    public class Usuario : IdentityUser
    {
        public Usuario() : base()
        {
            PreviousUserPasswords = new List<PreviousPasswords>();
        }

        [Column(TypeName = "DATE")]
        [Required]
        public DateTime SignupDate { get; set; }

        public virtual IList<PreviousPasswords> PreviousUserPasswords { get; set; }
    }
}
