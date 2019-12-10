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
    /// Lógica interna para ListarProjetos.xaml
    /// </summary>
    public partial class ListarProjetos : Window
    {
      
        public ListarProjetos()
        {
            InitializeComponent();
            dataGridProjetos.ItemsSource = n.Listar();
        }

        private string fotoP = string.Empty;
        NProjeto n = new NProjeto();
        private Projeto c;

        private void dataGridProjetos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DeletarProjeto_Click(object sender, RoutedEventArgs e)
        {
            NProjeto n = new NProjeto();

            Projeto c = new Projeto();
            if (dataGridProjetos.SelectedItem != null)
            {
                n.Delete((Projeto)dataGridProjetos.SelectedItem);
                n.Delete(c);
                dataGridProjetos.ItemsSource = null;
                dataGridProjetos.ItemsSource = n.Listar();
            }
            try { }
            catch
            {
                ErroDesconhecido erroD = new ErroDesconhecido();
                erroD.Show();
            }
        }

        private void EditarProjeto_Click(object sender, RoutedEventArgs e)
        {
            Projeto c = dataGridProjetos.SelectedItem as Projeto;
            if (dataGridProjetos.SelectedItem != null)
            {
                NomeTxt.Text = c.NomeP;
                SinopseTxt.Text = c.sinopse;
                EnderecoTxt.Text = c.endereco;
                LinksTxt.Text = c.linksDrive;
                CustoProjetoTxt.Text = Convert.ToString(c.preco);
                CustoConstrucaoTxt.Text = Convert.ToString(c.valorConstr);

                if (c != null)
                {
                    OpenFileDialog w = new OpenFileDialog();
                    w.Filter = "Arquivos Jpg|*.jpg|*.PNG|*.png|*.Png|*.JPEG|*.jpeg|*.Jpeg";
                    if (w.ShowDialog().Value)
                    {
                        byte[] b = File.ReadAllBytes(w.FileName);
                        c.fotoP = Convert.ToBase64String(b);

                        BitmapImage bi = new BitmapImage();
                        bi.BeginInit();
                        bi.StreamSource = new MemoryStream(b);
                        bi.EndInit();

                        fotoIcone.Source = bi;
                    }
                }
            }
        }

        private void AtualizarProjeto_Click(object sender, RoutedEventArgs e)
        {
            NProjeto n = new NProjeto();
            Projeto c = dataGridProjetos.SelectedItem as Projeto;
            if (dataGridProjetos.SelectedItem != null)
            {
                int i;
                c.NomeP = NomeTxt.Text;
                c.sinopse = SinopseTxt.Text;
                c.endereco = EnderecoTxt.Text;
                c.linksDrive = LinksTxt.Text;
                c.preco = Convert.ToDouble(CustoProjetoTxt.Text);
                c.valorConstr = Convert.ToDouble(CustoConstrucaoTxt.Text);

                if (!int.TryParse(CustoProjetoTxt.Text, out i))
                {
                    ErroNumBox errNum = new ErroNumBox();
                    errNum.Show();
                    return;
                }

                if (!int.TryParse(CustoProjetoTxt.Text, out i))
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
                dataGridProjetos.ItemsSource = n.Listar();

                ProjetoEditado ePj = new ProjetoEditado();
                ePj.Show();
            }
            else
            {
                ErroDesconhecido erroD = new ErroDesconhecido();
                erroD.Show();
            }
            
        }

        private void MostrarIcone_Click(object sender, RoutedEventArgs e)
        {
            Projeto c = dataGridProjetos.SelectedItem as Projeto;
            if (dataGridProjetos.SelectedItem != null)
            {
                try //(c.foto != null)
                {
                    byte[] b = Convert.FromBase64String(c.fotoP);

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
                fotoP = Convert.ToBase64String(b);

                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.StreamSource = new MemoryStream(b);
                bi.EndInit();

                fotoIcone.Source = bi;
            }
        }
        private void SelectClick(object sender, RoutedEventArgs e)
        {
            NProjeto n = new NProjeto();
            dataGridProjetos.ItemsSource = null;
            dataGridProjetos.ItemsSource = n.Select();
        }
      
        private void Checked_Checked(object sender, RoutedEventArgs e)
        {
            text1.Text = "Projeto finalizado! Parabéns!.";
        }
        private void Unchecked_Checked(object sender, RoutedEventArgs e)
        {
            text1.Text = "Projeto em andamento.";
        }
    }
}
