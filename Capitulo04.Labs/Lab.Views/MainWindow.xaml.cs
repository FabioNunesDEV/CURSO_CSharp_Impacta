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
using Lab.Models;

namespace Lab.Views
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            sexoComboBox.Items.Add(Sexos.Masculino);
            sexoComboBox.Items.Add(Sexos.Feminino);
        }

        private void incluirClienteButton_Click(object sender, RoutedEventArgs e)
        {
            //obtendo os dados do endereço
            Endereco endereco = new Endereco(
                ruaTextBox.Text,
                int.Parse(numeroTextBox.Text),
                cidadeTextBox.Text,
                cepTextBox.Text);

            //obtendo os dados do cliente
            Cliente cliente = new Cliente(
                cpfTextBox.Text,
                nomeTextBox.Text,
                (Sexos)sexoComboBox.SelectedItem,
                int.Parse(idadeTextBox.Text));

            cliente.EnderecoResidencial = endereco;

            MessageBox.Show(cliente.Exibir());
        }
    }
}
