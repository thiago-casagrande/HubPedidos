using System;
using System.Collections.Generic;
using System.Text;
using application.Processamento;
using Domain.Classificacao;
using Xunit;

namespace Tests;

public class CatalogoProcessadoresTests
{
    [Fact]
    public void Obter_DeveRetornarProcessadorPadrao()
    {
        var catalogo = new CatalogoProcessadores();

        var processador = catalogo.Obter(
            CategoriaProcessamento.Padrao,
            1);

        Assert.IsType<ProcessadorPadrao>(processador);
    }

    [Fact]
    public void Obter_DeveRetornarProcessadorPrioritario()
    {
        var catalogo = new CatalogoProcessadores();

        var processador = catalogo.Obter(
            CategoriaProcessamento.Prioritario,
            1);

        Assert.IsType<ProcessadorPrioritario>(processador);
    }

    [Fact]
    public void Obter_DeveFalharQuandoProcessadorNaoExistir()
    {
        var catalogo = new CatalogoProcessadores();

        Assert.Throws<InvalidOperationException>(() =>
            catalogo.Obter(CategoriaProcessamento.AltoValor, 1));
    }
}
