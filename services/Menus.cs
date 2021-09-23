using aj_bank.constants;
using aj_bank.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aj_bank.services
{
    public static class Menus
    {
        static Conta contaAtual;
        public static void PrintaMenuPrimario()
        {
            Console.WriteLine("\n1 - Criar Conta");
            Console.WriteLine("2 - Entrar com a conta");
            Console.WriteLine("3 - Listar Contas");
            Console.WriteLine("0 - Sair\n");
        }
        public static void MenuPincipal(List<Conta> contas)
        {
            string opcao;
            do
            {
                PrintarMenu();
                opcao = Console.ReadLine();
                switch (opcao)
                {
                    case "1":
                        Sacar();
                        break;
                    case "2":
                        Depositar();
                        break;
                    case "3":
                        Transferir(contas);
                        break;
                    case "4":
                        VisualizarConta();
                        break;
                    default:
                        break;
                }
            } while (opcao != "0");
        }

        internal static void ListarContas(List<Conta> contas)
        {
            foreach(Conta conta in contas)
            {
                Console.WriteLine(conta);
            }
        }

        public static void EntrarConta(List<Conta> contas)
        {
            try
            {
                Console.WriteLine("Informe o número da conta:");
                long numero = long.Parse(Console.ReadLine());
                contaAtual = contas.Find(c => c.Numero == numero);
                if (contaAtual == null)
                {
                    Console.WriteLine("Conta não encontrada");
                    return;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Dados Inválidos!");
            }
            MenuPincipal(contas);
        }

        private static void VisualizarConta()
        {
            Console.WriteLine(contaAtual);
        }

        private static void PrintarMenu()
        {
            Console.WriteLine("\n1 - Sacar");
            Console.WriteLine("2 - Depositar");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Visualizar saldo");
            Console.WriteLine("0 - Voltar\n");
        }
        public static void NovaConta(List<Conta> contas)
        {
            try
            {
                Console.WriteLine("Informe seu nome:");
                string nome = Console.ReadLine();

                PrintTipoConta();

                string tipo = Console.ReadLine();
                if (tipo != "1" && tipo != "2")
                {
                    while (tipo != "1" && tipo != "2")
                    {
                        Console.WriteLine("Dados inválidos");

                        PrintTipoConta();

                        tipo = Console.ReadLine();
                    }
                }

                TipoConta tipoConta;
                if (tipo == "1")
                {
                    tipoConta = TipoConta.PessoaFisica;
                }
                else
                {
                    tipoConta = TipoConta.PessoaJuridica;
                }

                Conta conta = new Conta(nome, 00.0, gerarLis(), tipoConta);

                if (conta != null)
                {
                    contas.Add(conta);
                    Console.WriteLine("Conta  criada com sucesso!");
                    contaAtual = conta;
                    MenuPincipal(contas);
                }
                else
                {
                    Console.WriteLine("Erro no sistema, a conta não pode ser criada!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Dados Inválidos!");
            }
        }

        private static void Sacar()
        {
            try
            {
                Console.WriteLine("Informe o valor:");
                double valor = double.Parse(Console.ReadLine());
                contaAtual.Sacar(valor);
            }
            catch (Exception e)
            {
                Console.WriteLine("Dados Inválidos!");
            }
        }

        private static void Depositar()
        {
            try
            {
                Console.WriteLine("Informe o valor:");
                double valor = double.Parse(Console.ReadLine());
                contaAtual.Depositar(valor, true);
            }
            catch (Exception e)
            {
                Console.WriteLine("Dados Inválidos!");
            }
        }

        private static void Transferir(List<Conta> contas)
        {
            try
            {
                Console.WriteLine("Informe o número da conta de transferencia:");
                long numero = long.Parse(Console.ReadLine());
                Conta conta = contas.Find(c => c.Numero == numero);
                if (conta != null)
                {
                    Console.WriteLine("Informe o valor:");
                    double valor = double.Parse(Console.ReadLine());
                    contaAtual.Transferir(conta, valor);

                }
                else
                {
                    Console.WriteLine("Conta de transferência não encontrada");
                }
            } catch(Exception e)
            {
                Console.WriteLine("Dados Inválidos!");
            }

        }

        private static void PrintTipoConta()
        {
            Console.WriteLine("\nSelecione o tipo de conta:");
            Console.WriteLine("1 - Pessoa Física");
            Console.WriteLine("2 - Pessoa Jurídica\n");
        }

        private static double gerarLis()
        {
            return 200.0;
        }


    }
}
