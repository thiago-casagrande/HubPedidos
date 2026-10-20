using System;
using System.Collections.Generic;
using System.Text;
using application.Mapeamentos;
using Domain.Contratos;
using Domain.Pedidos;

namespace Tests;

public class ItemPedidoMapeadorTests
{
    [Fact]
    public void ParaDominio_ComDadosValidos_DeveCriarItem()
    {
        var request = new CriarItemPedidoRequest(
            "Teclado",
            2,
            100m);

        ItemPedido item = ItemPedidoMapeador.ParaDominio(request);

        Assert.Equal("Teclado", item.Nome);
        Assert.Equal(2, item.Quantidade);
        Assert.Equal(100m, item.PrecoUnitario);
        Assert.Equal(200m, item.CalcularSubtotal());
    }

    [Fact]
    public void ParaDominio_ComQuantidadeInvalida_DeveLancarExcecao()
    {
        var request = new CriarItemPedidoRequest(
            "Teclado",
            0,
            100m);

        Assert.Throws<ArgumentException>(
            () => ItemPedidoMapeador.ParaDominio(request));
    }
}
