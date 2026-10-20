using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Contratos;

public sealed record CriarPedidoRequest(
    string NomeCliente,
    IReadOnlyList<CriarItemPedidoRequest> Itens
);
