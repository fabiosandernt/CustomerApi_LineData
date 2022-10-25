using Customer.Domain.Cadastro.ValueObject;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Customer.Domain.Cadastro.Rules
{
    public class CpfValidator : AbstractValidator<Cpf>
    {
        private const string Pattern = @"^\d{3}.?\d{3}.?\d{3}-?\d{2}$";

        public CpfValidator()
        {
            RuleFor(x => x.Numero)
                .NotEmpty()
                .Must(BeCpfValid).WithMessage("Cpf inválido");
        }

        private bool BeCpfValid(string valor) => Regex.IsMatch(valor, Pattern);
    }
}
