using System;
using System.Collections.Generic;
using System.Text;

using Domain.Pedidos;

namespace Tests;

public class PedidoIdTests
{
    [Fact]
    public void Criar_ComGuidValido_DeveCriarPedidoId()
    {
        // Arrange
        Guid valor = Guid.NewGuid();

        // Act
        PedidoId pedidoId = PedidoId.Criar(valor);

        // Assert
        Assert.Equal(valor, pedidoId.Valor);
    }

    [Fact]
    public void Criar_ComGuidVazio_DeveLancarExcecao()
    {
        // Act e Assert
        Assert.Throws<ArgumentException>(
            () => PedidoId.Criar(Guid.Empty));
    }
}

