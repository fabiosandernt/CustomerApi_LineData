using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Domain.Account.Enums
{
    public enum TipoUsuarioEnum : int
    {
        [Description("Administrador")]
        Administrador = 1,

        [Description("Cliente")]
        Clinica = 2,

        [Description("Funcionário")]
        Cliente = 3,
    }
}
