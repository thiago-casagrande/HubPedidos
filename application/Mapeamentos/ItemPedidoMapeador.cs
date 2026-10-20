using System;
using System.Collections.Generic;
using System.Text;

using Domain.Contratos;
using Domain.Pedidos;

namespace application.Mapeamentos;

public static class ItemPedidoMapeador
{
    public static ItemPedido ParaDominio(
        CriarItemPedidoRequest request)
    {
        return ItemPedido.Criar(
            request.Nome,
            request.Quantidade,
            request.PrecoUnitario);
    }
}
