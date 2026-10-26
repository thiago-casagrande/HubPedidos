using System;
using System.Collections.Generic;
using System.Text;
using Domain.Classificacao;

namespace application.Processamento;

public interface IProcessadorPedido
{
    CategoriaProcessamento Categoria { get; }

    int Versao { get; }

    string Processar(Guid pedidoId, decimal valorTotal);
}
