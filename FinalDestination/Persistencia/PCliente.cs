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
    public class PCliente
    {
        private string arquivo = "Clientes.xml";
        public List<Pessoa> Open()
        {
            XmlSerializer x = new XmlSerializer(typeof(List<Pessoa>));
            StreamReader f = null;
            List<Pessoa> cs = null;
            try
            {
                f = new StreamReader(arquivo, Encoding.Default);
                cs = x.Deserialize(f) as List<Pessoa>;
            }
            catch
            {
                cs = new List<Pessoa>();
            }
            finally
            {
                if (f != null) f.Close();
            }
            return cs;
        }
       
        public void Save(List<Pessoa> cs)
        {
            XmlSerializer x = new XmlSerializer(typeof(List<Pessoa>));
            StreamWriter f = new StreamWriter(arquivo, false, Encoding.Default);
            x.Serialize(f, cs);
            f.Close();
        }
    }
}