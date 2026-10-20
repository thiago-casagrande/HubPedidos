using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Contratos;

public sealed record CriarItemPedidoRequest(
    string Nome,
    int Quantidade,
    Decimal PrecoUnitario
    );