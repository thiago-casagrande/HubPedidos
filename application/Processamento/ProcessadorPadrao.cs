using System;
using System.Collections.Generic;
using System.Text;
using Domain.Classificacao;
using Domain.Processamento;

namespace application.Processamento;

[ProcessadorPedido(CategoriaProcessamento.Padrao, 1)]
public sealed class ProcessadorPadrao : IProcessadorPedido
{
    public CategoriaProcessamento Categoria =>
        CategoriaProcessamento.Padrao;

    public int Versao => 1;

    public string Processar(Guid pedidoId, decimal valorTotal)
    {
        return $"Pedido {pedidoId} processado pelo fluxo padrão. Total: {valorTotal:C}";
    }
}
