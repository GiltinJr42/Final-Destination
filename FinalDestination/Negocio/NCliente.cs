using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using Persistencia;

namespace Negocio
{
    public class NCliente
    {
        private List<Pessoa> clientes;
        private PCliente p = new PCliente();
        private int k = 0;
        public List<Pessoa> Listar()
        {
            clientes = p.Open();
            return clientes;
        }
        public void Inserir(Pessoa c)
        {
            clientes = p.Open();
            clientes.Add(c);
            p.Save(clientes);
        }
        public void Atualizar(Pessoa c)
        {
            clientes = p.Open();
            for(int i = 0; i < clientes.Count; i++)
            {
                if(clientes[i].Id == c.Id)
                {
                    clientes[i] = c;
                }
            }
            p.Save(clientes);
        }
        public void Excluir(Pessoa a)
        {
            clientes = p.Open();
            clientes.RemoveAt(clientes.IndexOf(a));
            p.Save(clientes);
        }
        
    }
}
