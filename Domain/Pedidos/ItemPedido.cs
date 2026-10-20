using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Pedidos;

public sealed record ItemPedido
{
    public string Nome { get; }
    public int Quantidade { get; }
    public decimal PrecoUnitario { get; }

    private ItemPedido(
        string nome,
        int quantidade,
        decimal precoUnitario)
    {
        Nome = nome;
        Quantidade = quantidade;
        PrecoUnitario = precoUnitario;
    }

    public static ItemPedido Criar(
        string nome,
        int quantidade,
        decimal precoUnitario)
    {
        if (string.IsNullOrWhiteSpace(nome))
        {
            throw new ArgumentException(
                "O nome do item é obrigatório.",
                nameof(nome));
        }

        if (quantidade <= 0)
        {
            throw new ArgumentException(
                "A quantidade deve ser maior que zero.",
                nameof(quantidade));
        }

        if (precoUnitario < 0)
        {
            throw new ArgumentException(
                "O preço não pode ser negativo.",
                nameof(precoUnitario));
        }

        return new ItemPedido(
            nome.Trim(),
            quantidade,
            precoUnitario);
    }

    public decimal CalcularSubtotal()
    {
        return Quantidade * PrecoUnitario;
    }
}
