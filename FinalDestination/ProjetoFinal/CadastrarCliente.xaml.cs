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

        private string fotoIcone = string.Empty;

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
            string f = fotoIcone;
            Pessoa p = new Pessoa();

            p.Nome = n; p.senha = s; p.Email = m; p.Fone = t; p.foto = f;
            cl.Inserir(p);
            ClienteAdicionado clientAdd = new ClienteAdicionado();



            this.Close();
            clientAdd.Show();

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
        /*private void List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (list.SelectedItem != null)
            {
                MUsuario u = list.SelectedItem as MUsuario;
                txtUsuario.Text = u.Nome;

                byte[] b = Convert.FromBase64String(u.Foto);

                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.StreamSource = new MemoryStream(b);
                bi.EndInit();

                image.Source = bi;
            }
        }*/
        private void AddImagemOpenWindow_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            IconeClienteAdicionado IconeCliente = new IconeClienteAdicionado();
            IconeCliente.Show();
        }
    }
}
