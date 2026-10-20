using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Contratos;

public sealed record PedidoResponse(
    Guid PedidoID, /// Identificador de pedido
    string NomeCliente, /// Nome do Cliente
    decimal ValorTotal, /// Valor total do pedido
    int QuantidadeItens /// Quantidade total de unidades pedidas
    );