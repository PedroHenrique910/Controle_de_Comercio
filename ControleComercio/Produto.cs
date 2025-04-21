using System;

namespace ControleComercio
{
    public class Produto
    {
        public int Codigo { get; private set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int QuantidadeEstoque { get; private set; }

        public Produto(int codigo, string nome, decimal preco, int quantidadeInicial)
        {
            Codigo = codigo;
            Nome = nome;
            Preco = preco;
            QuantidadeEstoque = quantidadeInicial;
        }

        public void AdicionarEstoque(int quantidade)
        {
            QuantidadeEstoque += quantidade;
        }

        public bool RemoverEstoque(int quantidade)
        {
            if (quantidade <= QuantidadeEstoque)
            {
                QuantidadeEstoque -= quantidade;
                return true;
            }

            return false;
        }

        public void ExibirInfo()
        {
            Console.WriteLine($"Código: {Codigo} | Nome: {Nome} | Preço: R${Preco} | Estoque: {QuantidadeEstoque}");
        }
    }
}
