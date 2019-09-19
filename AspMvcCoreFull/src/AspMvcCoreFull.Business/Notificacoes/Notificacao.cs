using AspMvcCoreFull.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AspMvcCoreFull.Business.Notificacoes
{
    public class Notificacao {
        public Notificacao(string mensagem)
        {
            Mensagem = mensagem;
        }

        public string Mensagem { get; private set; }
    }
}
