using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal
{
    class Projeto : Cliente
    {
        private string nome;
        private string endereco;
        private string resumoProjeto;
        private string metaEntrega;

        public Projeto(string nome, string ende, string resProj, string metaEntg)
        {
            this.nome = nome;
            endereco = ende;
            resumoProjeto = resProj;
            metaEntrega = metaEntg;
        }


    }
}
