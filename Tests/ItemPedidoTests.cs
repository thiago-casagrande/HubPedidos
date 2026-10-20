using System;
using System.Collections.Generic;
using System.Text;

using Domain.Pedidos;

namespace Tests;

public class ItemPedidoTests
{
    [Fact]
    public void Criar_ComDadosValidos_DeveCriarItem()
    {
        ItemPedido item = ItemPedido.Criar(
            "Teclado",
            2,
            100m);

        Assert.Equal("Teclado", item.Nome);
        Assert.Equal(2, item.Quantidade);
        Assert.Equal(100m, item.PrecoUnitario);
        Assert.Equal(200m, item.CalcularSubtotal());
    }

    [Fact]
    public void Criar_ComQuantidadeZero_DeveLancarExcecao()
    {
        Assert.Throws<ArgumentException>(
            () => ItemPedido.Criar("Teclado", 0, 100m));
    }

    [Fact]
    public void Criar_ComPrecoNegativo_DeveLancarExcecao()
    {
        Assert.Throws<ArgumentException>(
            () => ItemPedido.Criar("Teclado", 1, -10m));
    }

    [Fact]
    public void Criar_ComNomeVazio_DeveLancarExcecao()
    {
        Assert.Throws<ArgumentException>(
            () => ItemPedido.Criar("", 1, 100m));
    }
}