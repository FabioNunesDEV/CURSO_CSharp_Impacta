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
using System.IO;
using Lab.Models;
using Lab.Models.Utils;
using Lab.Arquivos;
using Microsoft.Win32;
using Lab.Dados;

namespace Lab.Views
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        ClientesDao clientesDao;
        ContasDao contasDao;
        MovimentoDao movimentoDao;
        public MainWindow()
        {
            InitializeComponent();
            sexoComboBox.Items.Add(Sexos.Masculino);
            sexoComboBox.Items.Add(Sexos.Feminino);
            sexoComboBox.SelectedIndex = 0;

            operacaoComboBox.Items.Add(Operacoes.Deposito);
            operacaoComboBox.Items.Add(Operacoes.Saque);
            operacaoComboBox.SelectedIndex = 0;

            clientesDao = new ClientesDao();
            contasDao = new ContasDao();
            movimentoDao = new MovimentoDao();

            clienteComboBox.ItemsSource = clientesDao.Listar();
            numeroContaComboBox.ItemsSource = contasDao.Listar();
        }

        private void incluirClienteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //obtendo os dados do endereço
                Endereco endereco = new Endereco(
                    0,
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
                //Metodos.AdicionarCliente(cliente);
                clientesDao.Incluir(cliente);

                //vinculando a lista de clientes ao componente Combobox
                //clienteComboBox.ItemsSource = Metodos.ListarClientes();
                clienteComboBox.ItemsSource = clientesDao.Listar();

                MessageBox.Show("Cliente incluído com sucesso !");

                //MessageBox.Show(cliente.Exibir());
            }
            catch (Exception ex)
            {
                AcessoArquivo.GerarLog(ex.Message);
                MessageBox.Show(ex.Message,
                "Erro",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
            }            
        }
        private bool VerificarEspecial { get; set; }
        private void especialRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                var radio = sender as RadioButton;

                VerificarEspecial = radio.Name == "especialRadioButton";
                limiteLabel.IsEnabled = VerificarEspecial;
                limiteTextBox.IsEnabled = VerificarEspecial;
            }
            catch (Exception ex)
            {
                AcessoArquivo.GerarLog(ex.Message);
                MessageBox.Show(ex.Message,"Erro",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }
        private void incluirContaButton_Click(object sender, RoutedEventArgs e)
        {
            try
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
                conta.NumeroDocumento = cliente.NumeroDocumento;

                //adicionamos a nova conta à lista de contas do
                //cliente selecionado
                cliente.Contas.Add(conta);

                //incluimos a nova conta à lista global de contas
                //Metodos.AdicionarConta(conta);
                contasDao.Incluir(conta);

                //vinculamos a lista global de contas ao
                //componente ComboBox
                //numeroContaComboBox.ItemsSource = Metodos.ListarContas();
                numeroContaComboBox.ItemsSource = contasDao.Listar();

                MessageBox.Show("Conta adicionada com sucesso!");
            }
            catch (Exception ex)
            {
                AcessoArquivo.GerarLog(ex.Message);
                MessageBox.Show(ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        private void executarButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //obtendo a conta selecionada
                var conta = (Conta)numeroContaComboBox.SelectedItem;
                //obtendo a operação
                var operacao = (Operacoes)operacaoComboBox.SelectedItem;
                //obtendo o valor da operação
                double valor = double.Parse(valorTextBox.Text);
                //executar a operação
                conta.EfetuarOperacao(valor, operacao);
                var movimento = new Movimento()
                {
                    IdConta = conta.Id,
                    Data = DateTime.Now,
                    Operacao = operacao,
                    Valor = valor,
                    Historico = operacao == Operacoes.Saque ?"SAQUE" : "DEPÓSITO"
                };
                movimentoDao.Incluir(movimento);
                MessageBox.Show("Operação realizada com sucesso!");
                valorTextBox.Clear();
            }
            catch (Exception ex)
            {
                AcessoArquivo.GerarLog(ex.Message);
                MessageBox.Show(ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        private void extratoButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var conta = (Conta)numeroContaComboBox.SelectedItem;
                //Buscar o extrato da conta selecionada
                conta.Movimentos = movimentoDao.Listar(conta.Id).ToList();
                conta.ClienteInfo = clientesDao.Buscar(conta.NumeroDocumento);
                extratoTextBox.Text = conta.MostrarExtrato();
            }
            catch (Exception ex)
            {
                AcessoArquivo.GerarLog(ex.Message);
                MessageBox.Show(ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        private void buscarButton_Click(object sender, RoutedEventArgs e)
        {
            ListaElementos<Cliente> lista = new ListaElementos<Cliente>();
            lista.CriarElementos(Metodos.ListarClientes().ToArray());
            var item = lista.Buscar(p => p.Nome.Contains(buscaTextBox.
            Text));
            resultadoListBox.Items.Clear();
            resultadoListBox.Items.Add(item);
        }
        private void listarButton_Click(object sender, RoutedEventArgs e)
        {
            ListaElementos<Cliente> lista = new ListaElementos<Cliente>();
            lista.CriarElementos(Metodos.ListarClientes().ToArray());
            var itens = lista.Listar(p => p.Nome.Contains(buscaTextBox.Text));
            resultadoListBox.Items.Clear();
            resultadoListBox.ItemsSource = itens;
        }
        private void salvarExtratoButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var conta = (Conta)numeroContaComboBox.SelectedItem;
                AcessoArquivo.GerarExtrato<Conta>(conta);
                MessageBox.Show("Extrato armazenado com sucesso!");
            }
            catch (Exception ex)
            {
                AcessoArquivo.GerarLog(ex.Message);
                MessageBox.Show(ex.Message,"Erro",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }
        private void abrirExtratoButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Arquivos txt (*.txt)|*.txt";
                dialog.InitialDirectory = Caminhos.caminhoExtrato;
                if (dialog.ShowDialog() == true)
                {
                    arquivoTextBox.Text = File.ReadAllText(dialog.
                    FileName);
                }
            }
            catch (Exception ex)
            {
                AcessoArquivo.GerarLog(ex.Message);
                MessageBox.Show(ex.Message,"Erro",MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void abrirLogButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string arquivo = Caminhos.caminhoLog;
                arquivoTextBox.Text = File.ReadAllText(arquivo);
            }
            catch (Exception ex)
            {
                AcessoArquivo.GerarLog(ex.Message);
                MessageBox.Show(ex.Message,
                "Erro",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
            }
        }
    }
}
