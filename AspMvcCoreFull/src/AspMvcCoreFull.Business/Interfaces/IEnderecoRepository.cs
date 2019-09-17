using AppMvcCoreBasica.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AspMvcCoreFull.Business.Interfaces
{
    public interface IEnderecoRepository
    {
        Task<Endereco> ObterEnderecoPorFornecedor(Guid fornecedorId);
    }
}
