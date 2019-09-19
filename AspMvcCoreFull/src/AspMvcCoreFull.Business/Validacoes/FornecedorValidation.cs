using AppMvcCoreBasica.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspMvcCoreFull.Business.Validacoes
{
    public class FornecedorValidation :AbstractValidator<Fornecedor>
    {
        public FornecedorValidation()
        {
            RuleFor(f => f.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            When(f => f.TipoFornecedor == TipoFornecedor.PessoaFisica, () => {
                RuleFor(f => f.Documento.Length).Equal(CpfValidacao.TamanhoCpf)
                .WithMessage("O campo Documento precitar ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}");

                RuleFor(f => CpfValidacao.Validar(f.Documento)).Equal(true)
                .WithMessage("O Documento não é um CPF válido");
            });

            //O mesmo, acima, para  CNPJ
            When(f => f.TipoFornecedor == TipoFornecedor.PessoaJuridica, () => {
                RuleFor(f => f.Documento.Length).Equal(CnpjValidacao.TamanhoCnpj)
                .WithMessage("O campo Documento precitar ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}");

                RuleFor(f => CnpjValidacao.Validar(f.Documento)).Equal(true)
                .WithMessage("O Documento não é um CNPJ válido");
            });
        }
    }

    //criar classe na pasta validacoes
    internal class CpfValidacao
    {
        public static int TamanhoCpf { get { return 11; }  }

        internal static bool Validar(string documento)
        {
            return true;
        }
    }

    internal class CnpjValidacao
    {
        public static int TamanhoCnpj { get { return 11; } }

        internal static bool Validar(string documento)
        {
            return false;
        }
    }
}
