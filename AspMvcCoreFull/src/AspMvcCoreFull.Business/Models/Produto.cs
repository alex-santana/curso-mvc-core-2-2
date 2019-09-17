using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppMvcCoreBasica.Models
{
    public class Produto : Entity
    {
        public Guid FornecedorId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Imagem { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataCadastro{ get; set; }
        public bool Ativo { get; set; }

        /*
         EF Relation - Relação do Produto com o fornecedor (1 produto - 1 fornecedor)
         */
        public Fornecedor Fornecedor { get; set; }
    }
}
