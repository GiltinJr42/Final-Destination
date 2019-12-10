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
using System.Data;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Modelo;
using Negocio;
using MediaFoundation.OPM;
namespace ProjetoFinal
{
    /// <summary>
    /// Lógica interna para FaturaMensal.xaml
    /// </summary>
    public partial class FaturaMensal : Window
    {

        Pessoa c = new Pessoa();
        Projeto p = new Projeto();
        NProjeto cl = new NProjeto();
        public FaturaMensal()
        {
            InitializeComponent();
            dataGridFatura.ItemsSource = cl.Listar();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            
            
        }
        private void DeletarFatura_Click(object sender, RoutedEventArgs e)
        {

            Projeto c = new Projeto();
            
            try { if (dataGridFatura.SelectedItem != null)
            {
                cl.Delete((Projeto)dataGridFatura.SelectedItem);
                dataGridFatura.ItemsSource = cl.Listar();
            }
            }
            catch
            {
                ErroDesconhecido erroD = new ErroDesconhecido();
                erroD.Show();
            }
        }
    }
}
