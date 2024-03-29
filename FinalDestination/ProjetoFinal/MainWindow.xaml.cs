﻿using System;
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
using Negocio;
using Modelo;


namespace ProjetoFinal
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        NCliente n = new NCliente();
        NProjeto p = new NProjeto();
        public MainWindow()
        {
            InitializeComponent();
            dataGridClientes.ItemsSource = n.Listar();
            dataGridProjetos.ItemsSource = p.Listar();
            dataGridFatura.ItemsSource = p.Listar();
            SomaFatura.Text += p.SomaFatura();

        }

        private void AdicionarCliente_Click(object sender, RoutedEventArgs e)
        {
            CadastrarCliente addCliente = new CadastrarCliente();
            addCliente.Show();
        }
        
        private void CadastrarProjeto_Click(object sender, RoutedEventArgs e)
        {
            CadastrarProjeto addPrj = new CadastrarProjeto();
            addPrj.Show();
        }
        private void FaturaMensal_Click(object sender, RoutedEventArgs e)
        {
            FaturaMensal FatMen = new FaturaMensal();
            FatMen.Show();
        }

        private void EditarCliente_Copy_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ListarProjetos_Click(object sender, RoutedEventArgs e)
        {
            ListarProjetos listProj = new ListarProjetos();
            listProj.Show();
        }
        private void ListarClientes_Click(object sender, RoutedEventArgs e)
        {
            ClienteListar listClient = new ClienteListar();
            listClient.Show();

        }
        private void AttLista_Click(object sender, RoutedEventArgs e)
        {
            dataGridClientes.ItemsSource = n.Listar();
        }
        private void AttListaProj_Click(object sender, RoutedEventArgs e)
        {
            dataGridProjetos.ItemsSource = p.Listar();
        }
        private void AttListaFatura_Click(object sender, RoutedEventArgs e)
        {
            dataGridClientes.ItemsSource = n.Listar();
            SomaFatura.Text = "Soma das faturas atuais:" + p.SomaFatura();
        }



    }
}
