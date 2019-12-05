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

namespace ProjetoFinal
{
    /// <summary>
    /// Lógica interna para ClienteListar.xaml
    /// </summary>
    public partial class ClienteListar : Window
    {
        public ClienteListar()
        {
            InitializeComponent();
        }

        private void dataGridClientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
