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
using System.Windows.Shapes;

namespace ProjetoFinal
{
    /// <summary>
    /// Lógica interna para ErroNumBox.xaml
    /// </summary>
    public partial class ErroNumBox : Window
    {
        public ErroNumBox()
        {
            InitializeComponent();
        }
        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
