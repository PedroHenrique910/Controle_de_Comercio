using System;
using System.Collections.Generic;

namespace ControleComercio
{
    class Program
    {
        static List<Produto> produtos = new List<Produto>();
        static int proximoCodigo = 1;

        static void Main(string[] args)
        {
            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("\n=== MENU ===");
                Console.WriteLine("1. Adicionar Produto");
                Console.WriteLine("2. Listar Produtos");
                Console.WriteLine("3. Adicionar Estoque");
                Console.WriteLine("4. Remover Estoque");
                Console.WriteLine("5. Realizar Venda");
                Console.WriteLine("0. Sair");
                Console.Write("Escolha uma opção: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        AdicionarProduto();
                        break;
                    case "2":
                        ListarProdutos();
                        break;
                    case "3":
                        AdicionarEstoque();
                        break;
                    case "4":
                        RemoverEstoque();
                        break;
                    case "5":
                        RealizarVenda();
                        break;
                    case "0":
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }

            Console.WriteLine("Sistema encerrado.");
        }

        static void RealizarVenda()
        {
            Console.WriteLine("\n--- Realizar Venda ---");
            ListarProdutos();

            Console.Write("Informe o código do produto: ");
            int codigo = int.Parse(Console.ReadLine() ?? "0");

            Produto? produto = produtos.Find(p => p.Codigo == codigo);

            if (produto != null)
            {
                Console.Write("Quantidade a vender: ");
                int quantidade = int.Parse(Console.ReadLine() ?? "0");

                if (quantidade <= produto.QuantidadeEstoque)
                {
                    decimal total = quantidade * produto.Preco;
                    produto.RemoverEstoque(quantidade);

                    Console.WriteLine("\n--- Comprovante ---");
                    Console.WriteLine($"Produto: {produto.Nome}");
                    Console.WriteLine($"Quantidade: {quantidade}");
                    Console.WriteLine($"Preço unitário: {produto.Preco:C}");
                    Console.WriteLine($"Total: {total:C}");
                    Console.WriteLine("Venda realizada com sucesso!");
                }
                else
                {
                    Console.WriteLine("Estoque insuficiente para essa quantidade.");
                }
            }
            else
            {
                Console.WriteLine("Produto não encontrado.");
            }

            // Voltar pro menu principal após a venda
            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
        }



        static void AdicionarProduto()
        {
            Console.Write("Nome do produto: ");
            string nome = Console.ReadLine() ?? "Produto Sem Nome";

            Console.Write("Preço: ");
            decimal preco = decimal.Parse(Console.ReadLine()?.Trim() ?? "0");

            Console.Write("Quantidade inicial: ");
            int quantidade = int.Parse(Console.ReadLine()?.Trim() ?? "0");

            Produto novoProduto = new Produto(proximoCodigo, nome, preco, quantidade);
            produtos.Add(novoProduto);
            Console.WriteLine($"Produto adicionado com sucesso! Código: {novoProduto.Codigo}");

            proximoCodigo++;
        }


        static void ListarProdutos()
        {
            Console.WriteLine("\n--- Lista de Produtos ---");
            foreach (Produto p in produtos)
            {
                p.ExibirInfo();
            }
        }

        static void AdicionarEstoque()
        {
            Console.Write("Informe o código do produto: ");
            int codigo = int.Parse(Console.ReadLine()?.Trim() ?? "0");

            Produto? produto = produtos.Find(p => p.Codigo == codigo);
            if (produto != null)
            {
                Console.Write("Quantidade a adicionar: ");
                int quantidade = int.Parse(Console.ReadLine()?.Trim() ?? "0");
                produto.AdicionarEstoque(quantidade);
                Console.WriteLine("Estoque atualizado!");
            }
            else
            {
                Console.WriteLine("Produto não encontrado.");
            }
        }

        static void RemoverEstoque()
        {
            Console.Write("Informe o código do produto: ");
            int codigo = int.Parse(Console.ReadLine()?.Trim() ?? "0");

            Produto? produto = produtos.Find(p => p.Codigo == codigo);
            if (produto != null)
            {
                Console.Write("Quantidade a remover: ");
                int quantidade = int.Parse(Console.ReadLine()?.Trim() ?? "0");

                if (produto.RemoverEstoque(quantidade))
                {
                    Console.WriteLine("Estoque atualizado!");
                }
                else
                {
                    Console.WriteLine("Quantidade insuficiente em estoque.");
                }
            }
            else
            {
                Console.WriteLine("Produto não encontrado.");
            }
        }
    }
}
