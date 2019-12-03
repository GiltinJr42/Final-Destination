using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Modelo;

namespace Persistencia
{
    public class Pprojeto
    {
        private string arquivo = "Projetos.xml";
        public List<Projeto> Open()
        {
            XmlSerializer x = new XmlSerializer(typeof(List<Projeto>));
            StreamReader f = null;
            List<Projeto> cs = null;
            try
            {
                f = new StreamReader(arquivo, Encoding.Default);
                cs = x.Deserialize(f) as List<Projeto>;
            }
            catch
            {
                cs = new List<Projeto>();
            }
            finally
            {
                if (f != null) f.Close();
            }
            return cs;
        }
        public void Save(List<Projeto> cs)
        {
            XmlSerializer x = new XmlSerializer(typeof(List<Projeto>));
            StreamWriter f = new StreamWriter(arquivo, false, Encoding.Default);
            x.Serialize(f, cs);
            f.Close();
        }
    }
}
