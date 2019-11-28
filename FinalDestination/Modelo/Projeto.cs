using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Projeto
    {
        public string nome { get; set; }
        public string endereco { get; set; }
        public string Sinopse { get; set; }
        public double Preco { get; set; }
        public double valorT { get; set; }
        public List<CR> c = new List<CR>();
        public List<Arq> a = new List<Arq>();
        public List<Est> e = new List<Est>();

        public Projeto(string nome, string ende, string resProj, string metaEntg)
        {
            this.nome = nome;
            endereco = ende;
            Sinopse = resProj;
        }

    }
}
