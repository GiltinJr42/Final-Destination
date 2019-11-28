using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ProjetoFinal
{
    class Cliente
    {
        private string nome;
        private string fone;
        private string email;
        private string resumoProjeto;
        private string pagamento;

        public Cliente(string nome, string fone, string email, string resProj, string pag)
        {
            this.nome = nome;
            this.fone = fone;
            this.email = email;
            resumoProjeto = resProj;
            pagamento = pag;
        }
        public static Cliente GetCliente()
        {
            var cln = new Cliente()
            {
                nome = nome, fone = fone, email = email, resumoProjeto = resumoProjeto, pagamento = pagamento;
            }
        }
    }
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            Clientes.Items.Add(new Cliente("joao", "11111111", "hotmailpontocom", "e", "e"));
        }
    }
}
