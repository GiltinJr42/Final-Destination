using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using Persistencia;

namespace Negocio
{
    public class NProjeto
    {
            private List<Projeto> projetos;
            private Pprojeto p = new Pprojeto();
            private int k = 0;
            public List<Projeto> Listar()
            {
                projetos = p.Open();
                return projetos;
            }
            public void Inserir(Projeto c)
            {
                projetos = p.Open();
                projetos.Add(c);
                p.Save(projetos);
            }
            public void Atualizar(Projeto c)
            {
                projetos = p.Open();
                for (int i = 0; i < projetos.Count; i++)
                {
                    if (projetos[i].Id == c.Id)
                    {
                        projetos[i] = c;
                    }
                }
                p.Save(projetos);
            }
            public void Excluir(Projeto a)
            {
                projetos = p.Open();
                projetos.RemoveAt(projetos.IndexOf(a));
                p.Save(projetos);
            }
        }
    }
