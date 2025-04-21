public class Produto
{
    private int Codigo { get; set; }
    private int QuantidadeEstoque { get; set; }
    public string Nome { get; set; }
    public decimal Preco {get; set; }

    public Produto (int codigo, int quantidadeEstoque, string nome, decimal preco)
    {
        Codigo = codigo;
        QuantidadeEstoque = quantidadeEstoque;
        Nome = nome;
        Preco = preco;
    }

     public void ReabastecerProduto(int produto)
     {
        QuantidadeEstoque += produto;
     }

     public bool RemoverDoEstoque(int produto)
     {
        if (produto <= QuantidadeEstoque)
        {
            QuantidadeEstoque -= produto;
            return true; 
        }

        return false;
     }

     public void ExibirInfo()
        {
            Console.WriteLine($"Código: {Codigo} | Nome: {Nome} | Preço: R${Preco} | Estoque: {QuantidadeEstoque}");
        }
}