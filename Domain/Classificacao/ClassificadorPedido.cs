using System;
using System.Collections.Generic;
using System.Text;
using Domain.Contratos;

namespace Domain.Classificacao;

public static class ClassificadorPedido
{
    public static CategoriaProcessamento Classificar(
        decimal valorTotal,
        int quantidadeItens,
        string regiao,
        bool prioritario)
    {
        return (valorTotal, quantidadeItens, regiao, prioritario) switch
        {
            ( < 0m, _, _, _) =>
                throw new ArgumentException(
                    "O valor total não pode ser negativo."),

            (_, < 0, _, _) =>
                throw new ArgumentException(
                    "A quantidade de itens não pode ser negativa."),

            (_, _, null or "", _) =>
                throw new ArgumentException(
                    "A região é obrigatória."),

            (_, _, _, true) =>
                CategoriaProcessamento.Prioritario,

            ( >= 1000m, _, _, _) =>
                CategoriaProcessamento.AltoValor,

            (_, >= 10, _, _) =>
                CategoriaProcessamento.AltoValor,

            _ => CategoriaProcessamento.Padrao
        };
    }
}

