using System;
using System.Collections.Generic;
using System.Text;
using Domain.Classificacao;
using Domain.Processamento;

namespace application.Processamento;

[ProcessadorPedido(CategoriaProcessamento.Prioritario, 1)]
public sealed class ProcessadorPrioritario : IProcessadorPedido
{
    public CategoriaProcessamento Categoria =>
        CategoriaProcessamento.Prioritario;

    public int Versao => 1;

    public string Processar(Guid pedidoId, decimal valorTotal)
    {
        return $"Pedido prioritário {pedidoId} processado. Total: {valorTotal:C}";
    }
}
