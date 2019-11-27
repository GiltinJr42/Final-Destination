﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal
{

    class Arquiteto
    {
        private Cliente[] clientes = new Cliente[100];
        private int k = 0;

        public Cliente[] Listar()
        {
            Cliente[] x = new Cliente[k];
            Array.Copy(clientes, x, k);
            return x;
        }
        public void Inserir(Cliente c)
        {
            clientes[k] = c;
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