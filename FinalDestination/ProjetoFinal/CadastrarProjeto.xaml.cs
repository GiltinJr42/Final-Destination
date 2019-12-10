using System;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using Negocio;
using Modelo;
using Persistencia;
using System.Collections.Generic;

namespace ProjetoFinal
{
    /// <summary>
    /// Lógica interna para CadastrarProjeto.xaml
    /// </summary>
    public partial class CadastrarProjeto : Window
    {
        public NProjeto cl = new NProjeto();
        private Projeto p = new Projeto();
        public NCliente nc = new NCliente();

        private string IconeProjeto = string.Empty;

        public CadastrarProjeto()
        {
            InitializeComponent();
            ClientesComboBox.ItemsSource = typeof(Pessoa).GetProperties();
            ClientesComboBox.ItemsSource = nc.Listar();
        }

        private void AdicionarProjeto_Click(object sender, RoutedEventArgs e)
        {
            string nome = NomeTxt.Text;
            string endereco = EnderecoTxt.Text;
            string sinopse = SinopseTxt.Text;
            string linksDrive = LinksTxt.Text;
            string fotoP = IconeProjeto;
            double preco = Convert.ToDouble(CustoProjeto.Text);
            double valorConstr = Convert.ToDouble(CustoConstrucao.Text);
            
            p.NomeP = nome; p.endereco = endereco; p.sinopse = sinopse; p.linksDrive = linksDrive; p.preco = preco; p.valorConstr = valorConstr; p.fotoP = fotoP; 
            cl.Inserir(p);
            ProjetoAdicionado projAdd = new ProjetoAdicionado();

            this.Close();
            projAdd.Show();
        }
        private void IconeProjeto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog w = new OpenFileDialog();
            w.Filter = "Arquivos Jpg|*.jpg|*.PNG|*.png|*.Png|*.JPEG|*.jpeg|*.Jpeg";
            if (w.ShowDialog().Value)
            {
                byte[] b = File.ReadAllBytes(w.FileName);
                IconeProjeto = Convert.ToBase64String(b);

                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.StreamSource = new MemoryStream(b);
                bi.EndInit();

                ImgDynamic.Source = bi;
            }
        }
      
        private void comboBox_DropDownClosed(object sender, EventArgs e)
        {
            
            p.NomeCliente = (ClientesComboBox.SelectedItem as Pessoa).Nome;
            p.clienteID = (ClientesComboBox.SelectedItem as Pessoa).Id;
            p.fotoIconeCliente = (ClientesComboBox.SelectedItem as Pessoa).foto;

        }
        private void Checked_Checked(object sender, RoutedEventArgs e)
        {
            text1.Text = "Projeto finalizado! Parabéns!";
        }
        private void Unchecked_Checked(object sender, RoutedEventArgs e)
        {
            text1.Text = "Projeto em andamento.";
        }


    }
}

