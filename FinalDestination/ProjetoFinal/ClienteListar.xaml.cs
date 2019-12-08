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

        NCliente n = new NCliente();
        private Pessoa c;

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
        }


        private void MostrarIcone_Click(object sender, RoutedEventArgs e)
        {
            Pessoa u = dataGridClientes.SelectedItem as Pessoa;
            if (dataGridClientes.SelectedItem != null)
            {
                if (u.foto != "")
                {
                    byte[] b = Convert.FromBase64String(u.foto);

                    BitmapImage bi = new BitmapImage();
                    bi.BeginInit();
                    bi.StreamSource = new MemoryStream(b);
                    bi.EndInit();

                    fotoIcone.Source = bi;
                }
                else
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
        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            Pessoa c = new Pessoa();
            PCliente p = new PCliente();
            List<Pessoa> cs = p.Open();
            string n = NomeTxt.Text;
            string m = EmailTxt.Text;
            string t = FoneTxt.Text;

            for (int i = 0; i < cs.Count; i++)
                if (cs[i].Id == c.Id)
                {
                    cs.RemoveAt(i);
                    break;
                }

            cs.Add(c);
            p.Save(cs);
        }
        private void Update_Click(object sender, RoutedEventArgs e)
        {
            Pessoa m = new Pessoa();
            m.Nome = NomeTxt.Text;
            m.Fone = FoneTxt.Text;
            m.Email = EmailTxt.Text;

            NCliente n = new NCliente();
            n.Update(m);
        }
        private void SelectClick(object sender, RoutedEventArgs e)
        {
            NCliente n = new NCliente();
            dataGridClientes.ItemsSource = null;
            dataGridClientes.ItemsSource = n.Select();
        }
    }
}