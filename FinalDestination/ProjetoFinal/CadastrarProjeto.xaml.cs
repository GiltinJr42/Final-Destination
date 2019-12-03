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
using Negocio;
using Modelo;
using ProjetoFinal;

namespace ProjetoFinal

{
    /// <summary>
    /// Lógica interna para CadastrarProjeto.xaml
    /// </summary>
    public partial class CadastrarProjeto : Window
    {
         public NProjeto cl = new NProjeto();

            public CadastrarProjeto()
            {
                InitializeComponent();
            }
            private void AddProjetoButton_Click(object sender, RoutedEventArgs e)
            {
                string nome = NomeProjeto.Text;
                string endereco = EnderecoProjeto.Text;
                string sinopse = SinopseProjeto.Text;
                string linksDrive = LinksGoogleDrive.Text;
                double preco = double.Parse(PrecoDeConstrucaoProjeto.Text);
                double valorConstr = double.Parse(PrecoProjeto.Text);
                Projeto p = new Projeto();

                p.nome = nome; p.endereco = endereco; p.sinopse = sinopse; p.linksDrive = linksDrive; p.preco = preco; p.valorConstr = valorConstr;
                cl.Inserir(p);
                ProjetoAdicionado projAdd = new ProjetoAdicionado();
                this.Close();
                projAdd.Show();

            }
        }
    }

