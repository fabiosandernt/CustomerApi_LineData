
using System.ComponentModel;


namespace Customer.Domain.Cadastro.Enums
{
    public enum TipoSexoEnum: int
    {
        [Description("Masculino")]
        Masculino = 1,

        [Description("Feminino")]
        Feminino = 2,

        [Description("Outros")]
        Outros = 3
    }
}
