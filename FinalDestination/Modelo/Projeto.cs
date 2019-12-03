using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace Modelo
{
    public class Projeto
    {
        public int Id { get; set; }
        public string nome { get; set; }
        public string endereco { get; set; }
        public string sinopse { get; set; }
        public double preco { get; set; }
        public double valorConstr { get; set; }
        public string linksDrive { get; set; }
        public string foto { get; set; }

        public List<CR> c = new List<CR>();
        public List<Arq> a = new List<Arq>();
        public List<Est> e = new List<Est>();

        /*public Projeto(int Id, string nome, string ende, string resProj, string linksDrive, double preco, double valorConst)
        {
            this.Id = Id;
            this.nome = nome;
            endereco = ende;
            sinopse = resProj;
            this.linksDrive = linksDrive;
            this.preco = preco;
            valorConstr = valorConst;
        }*/
        
    }
}
