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
using Modelo;
using Negocio;

namespace ProjetoFinal
{
    /// <summary>
    /// Lógica interna para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }
        public static bool VerificarSenha(string usuario, string senha)
        {
            bool r = false;
            if (usuario == "Admin")
            {
                r = senha == "12345";
            }
            if (r == false)
            {

                NCliente f = new NCliente();
                List<Pessoa> a = f.Listar();
                foreach (Pessoa x in a)
                {
                    string h = x.senha;
                    string te = "";
                    foreach (char pl in h)
                    {
                        int v = pl;
                        v -= 10;
                        te += Convert.ToChar(v);
                    }
                    if (x.Email == n && s == te)
                    {
                        r = true;
                        p = x.Tipo;
                        u = x;
                        break;
                    }
                }
            }

            return r;
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        
    }
}
