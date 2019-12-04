using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Modelo;
using Negocio;

namespace ProjetoFinal
{
    /// <summary>
    /// Lógica interna para CadastrarCliente.xaml
    /// </summary>
    public partial class CadastrarCliente : Window
    {
        public NCliente cl = new NCliente();

        public CadastrarCliente()
        {
            InitializeComponent();
        }
        private void Cads(object sender, RoutedEventArgs e)
        {
            string n = NomeCliente.Text;
            string s = SenhaCliente.Password;
            string m = EmailCliente.Text;
            string t = FoneCliente.Text;
            Pessoa p = new Pessoa();

            p.Nome = n; p.senha = s; p.Email = m; p.Fone = t;
            cl.Inserir(p);
            ClienteAdicionado clientAdd = new ClienteAdicionado();



            this.Close();
            clientAdd.Show();

        }
        private void AdicionarIconeCliente_Click(object sender, RoutedEventArgs e)
        {
            EscolherImagem escImg = new EscolherImagem();
            escImg.Show();

        }
    }
}
