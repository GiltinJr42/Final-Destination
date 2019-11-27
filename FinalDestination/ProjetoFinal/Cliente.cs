using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal
{
    class Cliente
    {
        private string nome;
        private string fone;
        private string email;
        private string resumoProjeto;
        private string pagamento;

        public Cliente(string nome, string fone, string email, string resProj, string pag)
        {
            this.nome = nome;
            this.fone = fone;
            this.email = email;
            resumoProjeto = resProj;
            pagamento = pag;
        }



    }
}
