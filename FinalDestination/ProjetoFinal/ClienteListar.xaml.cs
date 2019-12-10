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
using Persistencia;
using Negocio;
using Modelo;



namespace ProjetoFinal
{
    /// <summary>
    /// Lógica interna para ClienteListar.xaml
    /// </summary>
    /// 
    public partial class ClienteListar : Window
    {
        private string foto = string.Empty;
        int i;
        NCliente n = new NCliente();
        public Pessoa c;

        public ClienteListar()
        {
            InitializeComponent();
            dataGridClientes.ItemsSource = n.Listar();


        }

        private void dataGridClientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


        private void DeletarCliente_Click(object sender, RoutedEventArgs e)
        {
            NCliente n = new NCliente();

            Pessoa c = new Pessoa();
            if (dataGridClientes.SelectedItem != null)
            {
                n.Delete((Pessoa)dataGridClientes.SelectedItem);
                n.Delete(c);
                dataGridClientes.ItemsSource = null;
                dataGridClientes.ItemsSource = n.Listar();
            }
            try { }
            catch
            {
                ErroDesconhecido erroD = new ErroDesconhecido();
                erroD.Show();
            }
        }
        private void EditarCliente_Click(object sender, RoutedEventArgs e)
        {
            Pessoa c = dataGridClientes.SelectedItem as Pessoa;
            if (dataGridClientes.SelectedItem != null)
            {
                NomeTxt.Text = c.Nome;
                EmailTxt.Text = c.Email;
                FoneTxt.Text = c.Fone;
                if (c != null)
                {
                    OpenFileDialog w = new OpenFileDialog();
                    w.Filter = "Arquivos Jpg|*.jpg";
                    if (w.ShowDialog().Value)
                    {
                        byte[] b = File.ReadAllBytes(w.FileName);
                        c.foto = Convert.ToBase64String(b);

                        BitmapImage bi = new BitmapImage();
                        bi.BeginInit();
                        bi.StreamSource = new MemoryStream(b);
                        bi.EndInit();

                        fotoIcone.Source = bi;
                    }
                }
            }
        }
        private void AtualizarCliente_Click(object sender, RoutedEventArgs e)
        {
            Pessoa c = dataGridClientes.SelectedItem as Pessoa;
            Projeto p = new Projeto();

            c.Nome = NomeTxt.Text;
            p.NomeCliente = NomeTxt.Text;
            c.Fone = FoneTxt.Text;
            c.Email = EmailTxt.Text;
            c.foto = p.fotoIconeCliente;

            if (!int.TryParse(FoneTxt.Text, out i))
            {
                ErroNumBox errNum = new ErroNumBox();
                errNum.Show();
                return;
            }
            try { }
            catch
            {
                ErroDesconhecido erroD = new ErroDesconhecido();
                erroD.Show();
            }

            n.Update(c);
            dataGridClientes.ItemsSource = n.Listar();

            ClienteEditado cEd = new ClienteEditado();
            cEd.Show();
        }

        private void MostrarIcone_Click(object sender, RoutedEventArgs e)
        {
            Pessoa c = dataGridClientes.SelectedItem as Pessoa;
            if (dataGridClientes.SelectedItem != null)
            {
                try //(c.foto != null)
                {
                    byte[] b = Convert.FromBase64String(c.foto);

                    BitmapImage bi = new BitmapImage();
                    bi.BeginInit();
                    bi.StreamSource = new MemoryStream(b);
                    bi.EndInit();

                    fotoIcone.Source = bi;
                }
                catch //(c.foto == null)
                {
                    ErroVerIcone erroVer = new ErroVerIcone();
                    erroVer.Show();
                }
            }
        }

        private void AttIcone_Click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog w = new OpenFileDialog();
            w.Filter = "Arquivos Jpg|*.jpg|*.PNG|*.png|*.Png|*.JPEG|*.jpeg|*.Jpeg";
            if (w.ShowDialog().Value)
            {
                byte[] b = File.ReadAllBytes(w.FileName);
                foto = Convert.ToBase64String(b);

                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.StreamSource = new MemoryStream(b);
                bi.EndInit();

                fotoIcone.Source = bi;
            }
        }

        private void SelectClick(object sender, RoutedEventArgs e)
        {
            NCliente n = new NCliente();
            dataGridClientes.ItemsSource = null;
            dataGridClientes.ItemsSource = n.Select();
            try { }
            catch
            {
                ErroDesconhecido erroD = new ErroDesconhecido();
                erroD.Show();
            }
        }
    }
}
       
