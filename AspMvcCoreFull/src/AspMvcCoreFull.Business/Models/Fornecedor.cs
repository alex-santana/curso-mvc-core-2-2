using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppMvcCoreBasica.Models
{
    public class Fornecedor : Entity
    {
        public string Nome { get; set; }
        public string Documento { get; set; }
        public TipoFornecedor TipoFornecedor { get; set; }
        public Endereco Endereco { get; set; }
        public bool Ativo { get; set; }

        /*
         EF Relation - Relação do Fornecedor com Produto (1 fornecedor - N - Produtos)
         */
        public IEnumerable<Produto> Produtos { get; set; }
    }

    
}
