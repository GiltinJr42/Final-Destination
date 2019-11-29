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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjetoFinal
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void AdicionarCliente_Click(object sender, RoutedEventArgs e)
        {
            CadastrarCliente addCliente = new CadastrarCliente();
            addCliente.Show();
        }
        private void EditarProjeto_Click(object sender, RoutedEventArgs e)
        {
            EditarProjeto EdtPrj = new EditarProjeto();
            EdtPrj.Show();
        }
        private void CadastrarProjeto_Click(object sender, RoutedEventArgs e)
        {
            CadastrarProjeto AddPrj = new CadastrarProjeto();
            AddPrj.Show();
        }
        private void FaturaMensal_Click(object sender, RoutedEventArgs e)
        {
           FaturaMensal FatMen = new FaturaMensal();
            FatMen.Show();
        }
       


    }
}
