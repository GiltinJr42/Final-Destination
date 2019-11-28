using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal
{

    class Arquiteto : Cliente
    {
        private Cliente[] clientes = new Cliente[100];
        private int k = 0;

        public Cliente[] Listar()
        {
            
            return x;
        }

        private List<Cliente> cliente = new List<Cliente>();
        public void Inserir(Cliente c)
        {
            cliente.Add(c);
        }
        public void Inserir(Cliente c)
        {
            cliente[k] = c;
            k++;
        }
        public void Atualizar(int i, Curso p)
        {
            clientes[i - 1] = p;
        }
        public void Excluir(int m)
        {
            for (int i = m; i > clientes.Length; i++)
            {
                clientes[m - 1] = clientes[m];
            }
            k--;
        }
    }
}


//List<Cliente> a = lista.Open();