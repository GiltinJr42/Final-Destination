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
            private Projeto c = new Projeto();
            public List<Projeto> Listar()
            {
                projetos = p.Open();
                return projetos;
            }

            public List<Projeto> Select()
            {
                Pprojeto p = new Pprojeto();
                return p.Open().OrderBy(c => c.NomeP).ToList();
            }

            public List<Projeto> Pesquisar(string NomeP)
            {
                Pprojeto p = new Pprojeto();
                List<Projeto> cs = p.Open().OrderBy(c => c.NomeP).ToList();
                List<Projeto> r = new List<Projeto>();
                foreach (Projeto c in cs)
                    if (c.NomeP.StartsWith(NomeP)) r.Add(c);
                return r;
            }

            public void Inserir(Projeto c)
                {
                    Pprojeto p = new Pprojeto();
                    List<Projeto> cs = p.Open();
                    int m = 0;
                    foreach (Projeto x in cs) if (x.Id > m)
                        {
                            m = x.Id;
                        }
                    c.Id = m + 1;
                    cs.Add(c);
                    p.Save(cs);
                }

            public void Update(Projeto c)
            {
                Pprojeto p = new Pprojeto();
                List<Projeto> cs = p.Open();
                for (int i = 0; i < cs.Count; i++)
                    if (cs[i].Id == c.Id)
                    {
                        cs.RemoveAt(i);
                        break;
                    }
                cs.Add(c);
                p.Save(cs);
            }

            public void Delete(Projeto c)
            {
                Pprojeto p = new Pprojeto();
                List<Projeto> cs = p.Open();
                for (int i = 0; i < cs.Count; i++)
                    if (cs[i].Id == c.Id)
                    {
                        cs.RemoveAt(i);
                        break;
                    }
                p.Save(cs);
            }
            
            public double SomaFatura()
            {
                Pprojeto p = new Pprojeto();
                List<Projeto> cs = p.Open();
                double SomaF = 0;
                foreach (Projeto i in cs)
                {
                    SomaF += i.preco;
                
                }
            return SomaF;
        }
    }
}
