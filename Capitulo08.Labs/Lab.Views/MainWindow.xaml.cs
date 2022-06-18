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
using Lab.Models.Utils;

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
            sexoComboBox.SelectedIndex = 0;

            operacaoComboBox.Items.Add(Operacoes.Deposito);
            operacaoComboBox.Items.Add(Operacoes.Saque);
            operacaoComboBox.SelectedIndex = 0;
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
            int digitos = documentoTextBox.Text.Length;
            Cliente cliente;
            if (digitos == 11)
            {
                cliente = new ClientePF(
                documentoTextBox.Text,
                nomeTextBox.Text,
                (Sexos)sexoComboBox.SelectedItem,
                int.Parse(idadeTextBox.Text),
                endereco
                );
            }
            else if (digitos == 14)
            {
                cliente = new ClientePJ(
                documentoTextBox.Text,
                nomeTextBox.Text,
                (Sexos)sexoComboBox.SelectedItem,
                int.Parse(idadeTextBox.Text),
                endereco
                );
            }
            else
            {
                throw new Exception("Documento inválido");
            }

            //adicionando o novo cliente na lista
            Metodos.AdicionarCliente(cliente);

            //vinculando a lista de clientes ao componente Combobox
            clienteComboBox.ItemsSource = Metodos.ListarClientes();
            MessageBox.Show("Cliente incluído com sucesso !");

            //MessageBox.Show(cliente.Exibir());
        }

        private bool VerificarEspecial { get; set; }

        private void especialRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            var radio = sender as RadioButton;

            VerificarEspecial = radio.Name == "especialRadioButton";
            limiteLabel.IsEnabled = VerificarEspecial;
            limiteTextBox.IsEnabled = VerificarEspecial;
        }

        private void incluirContaButton_Click(object sender, RoutedEventArgs e)
        {
            Conta conta;
            var cliente = (Cliente)clienteComboBox.SelectedItem;
            int banco = int.Parse(bancoTextBox.Text);
            string agencia = agenciaTextBox.Text;
            string numConta = contaTextBox.Text;
            if (VerificarEspecial)
            {
                conta = new ContaEspecial(banco, agencia, numConta);
                ((ContaEspecial)conta).Limite = double.Parse(limiteTextBox.Text);
            }
            else
            {
                conta = new ContaCorrente(banco, agencia, numConta);
            }
            //vinculamos o cliente selecionado à nova conta
            conta.ClienteInfo = cliente;
            //adicionamos a nova conta à lista de contas do
            //cliente selecionado
            cliente.Contas.Add(conta);
            //incluimos a nova conta à lista global de contas
            Metodos.AdicionarConta(conta);
            //vinculamos a lista global de contas ao
            //componente ComboBox
            numeroContaComboBox.ItemsSource = Metodos.ListarContas();
            MessageBox.Show("Conta adicionada com sucesso!");
        }

        private void executarButton_Click(object sender, RoutedEventArgs e)
        {
            //obtendo a conta selecionada
            var conta = (Conta)numeroContaComboBox.SelectedItem;
            //obtendo a operação
            var operacao = (Operacoes)operacaoComboBox.SelectedItem;
            //obtendo o valor da operação
            double valor = double.Parse(valorTextBox.Text);
            //executar a operação
            conta.EfetuarOperacao(valor, operacao);
            MessageBox.Show("Operação realizada com sucesso!");
            valorTextBox.Clear();
        }

        private void extratoButton_Click(object sender, RoutedEventArgs e)
        {
            var conta = (Conta)numeroContaComboBox.SelectedItem;
            extratoTextBox.Text = conta.MostrarExtrato();
        }
    }
}
