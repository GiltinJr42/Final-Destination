using System;
using System.Collections.Generic;
using System.IO;
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
using Microsoft.Win32;
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
        private void BtnLoadFromFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog w = new OpenFileDialog();
            w.Filter = "Arquivos Jpg|*.jpg|*.PNG|*.png|*.Png|*.JPEG|*.jpeg|*.Jpeg";
            if (w.ShowDialog().Value)
            {
                byte[] b = File.ReadAllBytes(w.FileName);
                fotoIcone = Convert.ToBase64String(b);

                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.StreamSource = new MemoryStream(b);
                bi.EndInit();

                imgDynamic.Source = bi;

            }
        }
    }
    }

