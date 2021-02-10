using System;
using System.Collections.Generic;

namespace Bank
{
    class Program
    {
			static List<Conta> listAcc = new List<Conta>();
			static void Main(string[] args)
			{
				string userOption = GetUserOption();

				while (userOption.ToUpper() != "X")
				{
					switch (userOption)
					{
						case "1":
							ListarContas();
							break;
						case "2":
							InserirConta();
							break;
						case "3":
							Transferir();
							break;
						case "4":
							Sacar();
							break;
						case "5":
							Depositar();
							break;
						case "C":
							Console.Clear();
							break;

						default:
							throw new ArgumentOutOfRangeException();
					}

					userOption = GetUserOption();
				}

				Console.WriteLine("Obrigado por utilizar nossos serviços.");
				Console.ReadLine();
			}

			private static void Depositar()
			{
				Console.Write("Digite o número da conta: ");
				int accIndex = int.Parse(Console.ReadLine());

				Console.Write("Digite o valor a ser depositado: ");
				double valorDeposito = double.Parse(Console.ReadLine());

				listAcc[accIndex].Depositar(valorDeposito);
			}

			private static void Sacar()
			{
				Console.Write("Digite o número da conta: ");
				int accIndex = int.Parse(Console.ReadLine());

				Console.Write("Digite o valor a ser sacado: ");
				double pickValue = double.Parse(Console.ReadLine());

				listAcc[accIndex].Pick(pickValue);
			}

			private static void Transferir()
			{
				Console.Write("Digite o número da conta de origem: ");
				int indiceContaOrigem = int.Parse(Console.ReadLine());

				Console.Write("Digite o número da conta de destino: ");
				int indiceContaDestino = int.Parse(Console.ReadLine());

				Console.Write("Digite o valor a ser transferido: ");
				double valorTransferencia = double.Parse(Console.ReadLine());

				listAcc[indiceContaOrigem].Transferir(valorTransferencia, listAcc[indiceContaDestino]);
			}

			private static void InserirConta()
			{
				Console.WriteLine("Inserir nova conta");

				Console.Write("Digite 1 para Conta Fisica ou 2 para Juridica: ");
				int entradaTipoConta = int.Parse(Console.ReadLine());

				Console.Write("Digite o Nome do Cliente: ");
				string entradaNome = Console.ReadLine();

				Console.Write("Digite o saldo inicial: ");
				double entradaSaldo = double.Parse(Console.ReadLine());

				Console.Write("Digite o crédito: ");
				double entradaCredito = double.Parse(Console.ReadLine());

				Conta novaConta = new Conta(accountType: (AccountType)entradaTipoConta, balance: entradaSaldo, credit: entradaCredito, name: entradaNome);


                listAcc.Add(novaConta);
			}

			private static void ListarContas()
			{
				Console.WriteLine("Listar contas");

				if (listAcc.Count == 0)
				{
					Console.WriteLine("Nenhuma conta cadastrada.");
					return;
				}

				for (int i = 0; i < listAcc.Count; i++)
				{
					Conta conta = listAcc[i];
					Console.Write("#{0} - ", i);
					Console.WriteLine(conta);
				}
			}

			private static string GetUserOption()
			{
				Console.WriteLine();
				Console.WriteLine("DIO Bank a seu dispor!!!");
				Console.WriteLine("Informe a opção desejada:");

				Console.WriteLine("1- Listar contas");
				Console.WriteLine("2- Inserir nova conta");
				Console.WriteLine("3- Transferir");
				Console.WriteLine("4- Sacar");
				Console.WriteLine("5- Depositar");
				Console.WriteLine("C- Limpar Tela");
				Console.WriteLine("X- Sair");
				Console.WriteLine();

				string userOption = Console.ReadLine().ToUpper();
				Console.WriteLine();
				return userOption;
			}
    }
}
