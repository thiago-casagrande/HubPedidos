using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Pedidos;

public sealed record PedidoId
{
    public Guid Valor { get;}
    
    private PedidoId(Guid valor)
    {
        Valor = valor;
    }

    public static PedidoId Criar(Guid valor)
    {
        if (valor == Guid.Empty)
        {
            throw new ArgumentException(
                "O identifacdor do pedido não pode ser vazio.",
                nameof(valor));
        }
        return new PedidoId(valor);
    }
}