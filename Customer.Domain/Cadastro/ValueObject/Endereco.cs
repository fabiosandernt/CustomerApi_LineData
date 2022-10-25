using Customer.Domain.Account.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Domain.Cadastro.ValueObject
{
    public class Endereco
    {
        public string NomeEndereco { get; set; }
        private string NormalizedStreet => NomeEndereco?.Trim().Trim().ToUpper();

        public string Cidade { get; set; }
        private string NormalizedCity => Cidade?.Trim().ToUpper();

        public string Estado { get; set; }
        private string NormalizedState => Estado?.Trim().ToUpper();

        public override string ToString()
        {
            var value = new[]
            {
                NomeEndereco,
                !string.IsNullOrWhiteSpace(NomeEndereco) && !string.IsNullOrWhiteSpace(Estado) ? $"{Cidade}-{Estado}" :
                !string.IsNullOrWhiteSpace(Cidade) ? Cidade : ""
            };

            return string.Join(", ", value.Where(x => !string.IsNullOrWhiteSpace(x)));
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = !string.IsNullOrWhiteSpace(NormalizedState)
                    ? NormalizedStreet.GetHashCode()
                    : 0;
                hashCode = hashCode * 397 ^ (!string.IsNullOrWhiteSpace(NormalizedCity)
                    ? NormalizedCity.GetHashCode()
                    : 0);
                hashCode = hashCode * 397 ^ (!string.IsNullOrWhiteSpace(NormalizedState)
                    ? NormalizedState.GetHashCode()
                    : 0);
                return hashCode;
            }
        }
    }
}
