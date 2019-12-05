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
    public partial class ClienteListar : Window
    {
        NCliente n = new NCliente();
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
            else;
            {
               
            }

        }

        private void MostrarIcone_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridClientes.SelectedItem != null)
            {
                Pessoa u = dataGridClientes.SelectedItem as Pessoa;
                byte[] b = Convert.FromBase64String(u.foto);
                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.StreamSource = new MemoryStream(b);
                bi.EndInit();
                Foto.Source = bi;
            }
        }
    }
}