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
                dataGridProjetos.ItemsSource = null;
                dataGridProjetos.ItemsSource = n.Listar();
            }
            else
            {
                ErroExcluirProjetoNull erroExcProj = new ErroExcluirProjetoNull();
                erroExcProj.Show();

            }
        }


        private void MostrarIcone_Click(object sender, RoutedEventArgs e)
        {
            Projeto u = dataGridProjetos.SelectedItem as Projeto;

            if (dataGridProjetos.SelectedItem != null)
            {
                if (u.fotoP != "")
                {
                    byte[] b = Convert.FromBase64String(u.fotoP);

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
                fotoP = Convert.ToBase64String(b);

                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.StreamSource = new MemoryStream(b);
                bi.EndInit();

                fotoIcone.Source = bi;
            }
        }
        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            Projeto c = new Projeto();
            Pprojeto p = new Pprojeto();
            List<Projeto> cs = p.Open();
            string n = NomeTxt.Text;
            string a = EnderecoTxt.Text;
            string l = LinksTxt.Text;
            string s = SinopseTxt.Text;
            double m = double.Parse(CustoProjetoTxt.Text);
            double d = double.Parse(CustoConstrucaoTxt.Text);

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
            Projeto m = new Projeto();
            m.NomeP = NomeTxt.Text;
            m.sinopse = SinopseTxt.Text;
            m.endereco = EnderecoTxt.Text;
            m.linksDrive = LinksTxt.Text;
            m.preco = double.Parse(CustoProjetoTxt.Text);
            m.valorConstr = double.Parse(CustoConstrucaoTxt.Text);

            NProjeto n = new NProjeto();
            n.Update(m);
        }
        private void SelectClick(object sender, RoutedEventArgs e)
        {
            NProjeto n = new NProjeto();
            dataGridProjetos.ItemsSource = null;
            dataGridProjetos.ItemsSource = n.Select();
        }

        private void checkBox_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
