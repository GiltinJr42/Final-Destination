using System;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using Negocio;
using Modelo;

namespace ProjetoFinal
{
    /// <summary>
    /// Lógica interna para CadastrarProjeto.xaml
    /// </summary>
    public partial class CadastrarProjeto : Window
    {
        public NProjeto cl = new NProjeto();

        private string IconeProjeto = string.Empty;

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
            string fotoP = IconeProjeto;
            double preco = double.Parse(PrecoDeConstrucaoProjeto.Text);     
            double valorConstr = double.Parse(PrecoProjeto.Text);
            
            Projeto p = new Projeto();
            p.NomeP = nome; p.endereco = endereco; p.sinopse = sinopse; p.linksDrive = linksDrive; p.preco = preco; p.valorConstr = valorConstr; p.fotoP = fotoP ;
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
                IconeProjeto = Convert.ToBase64String(b);

                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.StreamSource = new MemoryStream(b);
                bi.EndInit();

                ImgDynamic.Source = bi;
            }
        }
    }
}

