using System;
using System.Collections.Generic;
using System.Text;
using Domain.Classificacao;

namespace Domain.Processamento;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
public sealed class ProcessadorPedidoAttribute : Attribute
{
    public CategoriaProcessamento Categoria { get; }
    public int Versao { get; }

    public ProcessadorPedidoAttribute(
        CategoriaProcessamento categoria,
        int versao)
    {
        if (versao <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(versao),
                "A versão deve ser maior que zero.");
        }

        Categoria = categoria;
        Versao = versao;
    }
}
