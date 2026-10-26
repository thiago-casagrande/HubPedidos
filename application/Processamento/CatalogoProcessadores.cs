using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Domain.Classificacao;
using Domain.Processamento;

namespace application.Processamento;

public sealed class CatalogoProcessadores
{
    private readonly Dictionary<
        (CategoriaProcessamento Categoria, int Versao),
        IProcessadorPedido> _processadores = new();

    public CatalogoProcessadores()
    {
        // Examina somente o assembly conhecido da interface.
        Assembly assembly = typeof(IProcessadorPedido).Assembly;

        var tipos = assembly.GetTypes()
            .Where(tipo =>
                tipo.IsClass &&
                !tipo.IsAbstract &&
                typeof(IProcessadorPedido).IsAssignableFrom(tipo))
            .OrderBy(tipo => tipo.FullName, StringComparer.Ordinal);

        foreach (Type tipo in tipos)
        {
            var atributo = tipo.GetCustomAttribute<ProcessadorPedidoAttribute>();

            if (atributo is null)
            {
                throw new InvalidOperationException(
                    $"O processador {tipo.Name} não possui o atributo ProcessadorPedido.");
            }

            var construtor = tipo.GetConstructor(Type.EmptyTypes);

            if (construtor is null)
            {
                throw new InvalidOperationException(
                    $"O processador {tipo.Name} precisa de um construtor público sem parâmetros.");
            }

            var processador = (IProcessadorPedido)Activator.CreateInstance(tipo)!;

            if (processador.Categoria != atributo.Categoria ||
                processador.Versao != atributo.Versao)
            {
                throw new InvalidOperationException(
                    $"Os dados do atributo não correspondem aos do processador {tipo.Name}.");
            }

            var chave = (atributo.Categoria, atributo.Versao);

            if (_processadores.ContainsKey(chave))
            {
                throw new InvalidOperationException(
                    $"Já existe um processador para a categoria {atributo.Categoria}, versão {atributo.Versao}.");
            }

            _processadores.Add(chave, processador);
        }
    }

    public IProcessadorPedido Obter(
        CategoriaProcessamento categoria,
        int versao)
    {
        if (_processadores.TryGetValue((categoria, versao), out var processador))
        {
            return processador;
        }

        throw new InvalidOperationException(
            $"Não existe processador para a categoria {categoria}, versão {versao}.");
    }
}
