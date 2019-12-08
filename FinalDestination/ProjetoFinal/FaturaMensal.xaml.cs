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

namespace ProjetoFinal
{
    /// <summary>
    /// Lógica interna para FaturaMensal.xaml
    /// </summary>
    public partial class FaturaMensal : Window
    {
        NCliente n = new NCliente();
        NProjeto p = new NProjeto();
        public FaturaMensal()
        {
            InitializeComponent();
            dataGridFatura.ItemsSource = n.Listar();
            dataGridFatura.ItemsSource = p.Listar();
        }
    }
}
