using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace moneyucab_portalweb_back.EntitiesForm
{
    public class PreviousPasswords
    {
        public PreviousPasswords()
        {
            FechaCreacion = DateTime.Now;
        }

        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid PasswordID { get; set; }

        [Column(Order = 1)]
        public string PasswordHash { get; set; }

        [Column(Order = 2)]
        public DateTime FechaCreacion { get; set; }

        [Column(Order = 3)]
        public string UsuarioID { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
