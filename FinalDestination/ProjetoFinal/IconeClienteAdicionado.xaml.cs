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
    /// Lógica interna para IconeClienteAdicionado.xaml
    /// </summary>
    public partial class IconeClienteAdicionado : Window
    {
        public IconeClienteAdicionado()
        {
            InitializeComponent();
        }
        private void OKProjetoADD_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
