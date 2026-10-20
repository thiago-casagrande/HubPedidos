using System;
using System.Collections.Generic;
using System.Text;
using Domain.Classificacao;

namespace Tests;

public class ClassificadorPedidoTests
{
    [Fact]
    public void Classificar_PedidoPrioritario_DeveRetornarPrioritario()
    {
        var resultado = ClassificadorPedido.Classificar(
            100m, 1, "RJ", true);

        Assert.Equal(
            CategoriaProcessamento.Prioritario,
            resultado);
    }

    [Fact]
    public void Classificar_ValorAlto_DeveRetornarAltoValor()
    {
        var resultado = ClassificadorPedido.Classificar(
            1000m, 1, "RJ", false);

        Assert.Equal(
            CategoriaProcessamento.AltoValor,
            resultado);
    }

    [Fact]
    public void Classificar_MuitosItens_DeveRetornarAltoValor()
    {
        var resultado = ClassificadorPedido.Classificar(
            100m, 10, "RJ", false);

        Assert.Equal(
            CategoriaProcessamento.AltoValor,
            resultado);
    }

    [Fact]
    public void Classificar_CasoComum_DeveRetornarPadrao()
    {
        var resultado = ClassificadorPedido.Classificar(
            100m, 2, "RJ", false);

        Assert.Equal(
            CategoriaProcessamento.Padrao,
            resultado);
    }


    [Fact]
    public void Classificar_ComValorNegativo_DeveLancarExcecao()
    {
        Assert.Throws<ArgumentException>(
            () => ClassificadorPedido.Classificar(
                -10m, 1, "SP", false));
    }

    [Fact]
    public void Classificar_ComRegiaoVazia_DeveLancarExcecao()
    {
        Assert.Throws<ArgumentException>(
            () => ClassificadorPedido.Classificar(
                100m, 1, "", false));
    }
}