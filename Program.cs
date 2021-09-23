using aj_bank.model;
using aj_bank.services;
using System;
using System.Collections.Generic;

namespace aj_bank
{
    class Program
    {

        static List<Conta> contas = new List<Conta>();
        static void Main(string[] args)
        {
            Console.WriteLine("Bem vindo ao AJ Bank!");
            string opcao;
            do
            {

                Console.WriteLine("\nSeleciona uma opção para continuar:");
                Menus.PrintaMenuPrimario();
                opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        Menus.NovaConta(contas);
                        break;
                    case "2":
                        Menus.EntrarConta(contas);
                        break;
                    case "3":
                        Menus.ListarContas(contas);
                        break;
                    default:
                        break;
                }
            } while (opcao != "0");

        }
    }
}
