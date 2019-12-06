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

            public List<Pessoa> Listar()
            {
                clientes = p.Open();
                return clientes;
            }
            public List<Pessoa> Pesquisar(string nome)
            {
                PCliente p = new PCliente();
                List<Pessoa> cs = p.Open().OrderBy(c => c.Nome).ToList();
                List<Pessoa> r = new List<Pessoa>();
                foreach (Pessoa c in cs)
                    if (c.Nome.StartsWith(nome)) r.Add(c);
                return r;
            }
            public List<Pessoa> Select()
            {
                PCliente p = new PCliente();
                return p.Open().OrderBy(c => c.Nome).ToList();
            }
            public void Inserir(Pessoa c)
            {
                PCliente p = new PCliente();
                List<Pessoa> cs = p.Open();
                int m = 0;
                foreach (Pessoa x in cs) if (x.Id > m)
                    {
                        m = x.Id;
                    }
                c.Id = m + 1;
                cs.Add(c);
                p.Save(cs);
            }
            public void Update(Pessoa c)
            {
                PCliente p = new PCliente();
                List<Pessoa> cs = p.Open();
                for (int i = 0; i < cs.Count; i++)
                    if (cs[i].Id == c.Id)
                    {
                        cs.RemoveAt(i);
                        break;
                    }
                cs.Add(c);
                p.Save(cs);
            }
            public void Delete(Pessoa c)
            {
                PCliente p = new PCliente();
                List<Pessoa> cs = p.Open();
                for (int i = 0; i < cs.Count; i++)
                    if (cs[i].Id == c.Id)
                    {
                        cs.RemoveAt(i);
                        break;
                    }
                p.Save(cs);
            }
    }
}
