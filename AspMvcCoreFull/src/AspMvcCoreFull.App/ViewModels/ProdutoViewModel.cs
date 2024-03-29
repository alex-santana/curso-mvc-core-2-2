﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspMvcCoreFull.App.ViewModels
{
    public class ProdutoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Fornecedor")]
        public Guid FornecedorId { get; set; }

        [Required(ErrorMessage ="O campo {0} é obrigatório")]
        [StringLength(100,ErrorMessage ="O campo {0} deve conter entre {2} e {1} de caracteres",MinimumLength =2)]
        public string Nome { get; set; }
        [Required(ErrorMessage ="O campo {0} é obrigatório")]
        [StringLength(100,ErrorMessage ="O campo {0} deve conter entre {2} e {1} de caracteres",MinimumLength =2)]
        public string Descricao { get; set; }

        [DisplayName("Imagem do Produto")]
        public IFormFile ImagemUpload { get; set; }
        public string Imagem { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal Valor { get; set; }
        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }
        [DisplayName("Ativo?")]
        public bool Ativo { get; set; }
        [ScaffoldColumn(false)]
        public FornecedorViewModel Fornecedor { get; set; }
        [ScaffoldColumn(false)]
        public IEnumerable<FornecedorViewModel> Fornecedores { get; set; }
    }
}
