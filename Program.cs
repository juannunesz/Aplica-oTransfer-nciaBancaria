using System;
using System.Collections.Generic;

namespace AppBancario
{
    class Program
    {
        static List<Conta> listConta = new List<Conta>();

        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while(opcaoUsuario != "x")
            {
                switch(opcaoUsuario)
                {
                    case "1":
                        listarContas();
                        break;
                    case "2":
                        inserirConta();
                        break;
                    case "3":
                        transferir();
                        break;
                    case "4":
                        sacar();
                        break;
                    case "5":
                        depositar();
                        break;
                    case "c":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por usar nossos serviços.");
            Console.WriteLine();
            
        }


        private static void transferir(){
            Console.WriteLine("Digite o numero da conta de origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o numero da conta de destino");
            int indcieContaDestino = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser transferido: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            listConta[indiceContaOrigem].transferir(valorTransferencia,listConta[indcieContaDestino]);
        }
        private static void sacar(){
            Console.WriteLine("Digite o número da conta");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser sacado");
            double valorDeposito = double.Parse(Console.ReadLine());

            listConta[indiceConta].sacarDinheiro(valorDeposito);
        }
        private static void depositar(){
            Console.WriteLine("Digite o número  da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser depositado: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listConta[indiceConta].depositar(valorDeposito);
        }
        private static void listarContas(){
            Console.WriteLine("Listar Contas");

            if(listConta.Count == 0){
                Console.WriteLine("Nenhuma conta encontrada");
                return;
            }

            for(int i = 0; i < listConta.Count; i++){
                Conta conta = listConta[i];
                Console.Write("#{0} - ",i);
                Console.WriteLine(conta);
            }
        }
        private static void inserirConta()
        {
            Console.WriteLine("Inserir nova conta");
            Console.WriteLine("Digite 1 para conta fisica ou 2 para conta Juridica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o nome do cliente: ");
            string entradaNome = Console.ReadLine();

            Console.WriteLine("Digite o saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Credito inicial: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(
                tipoConta: (TipoConta)entradaTipoConta,
                saldo: entradaSaldo,
                credito: entradaCredito,
                nome: entradaNome);
            listConta.Add(novaConta);
        }
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Nosso Banco ao seu dispor!!!");
            Console.WriteLine("Informe a opção desejada");

            Console.WriteLine("1- Listas de Contas");
            Console.WriteLine("2- Inserir nova conta");
            Console.WriteLine("3- Transferir");
            Console.WriteLine("4- Sacar");
            Console.WriteLine("5- Depositar");
            Console.WriteLine("C- Limpar tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
