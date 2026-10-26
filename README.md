# HubPedidos

Projeto desenvolvido em C# e .NET para a disciplina de Programação Aplicada em .NET, do curso de Análise e Desenvolvimento de Sistemas.

## Sobre o projeto

O HubPedidos é uma aplicação voltada ao processamento de pedidos. O projeto trabalha com contratos imutáveis, validação de dados, classificação de pedidos e seleção de processadores.

## Tecnologias utilizadas

- C#
- .NET 10
- ASP.NET Core Web API
- Testes automatizados com xUnit
- Git e GitHub

## Funcionalidades desenvolvidas

- Modelagem de pedidos e itens com records.
- Validação de dados do domínio.
- Classificação de pedidos com pattern matching.
- Criação de processadores por categoria e versão.
- Descoberta controlada de processadores por reflexão.
- Testes automatizados do domínio e do catálogo.

## Estrutura da solução

- `Api`: camada da API.
- `Domain`: contratos, entidades e regras de domínio.
- `application`: mapeamentos e processamento de pedidos.
- `Tests`: testes automatizados.

## Como executar

1. Abra `HubPedidos.slnx` no Visual Studio.
2. Defina o projeto `Api` como projeto de inicialização.
3. Execute a aplicação com F5.
4. Para executar os testes, abra o Gerenciador de Testes e selecione **Executar Todos os Testes**.

## Status

Em desenvolvimento.

O projeto está sendo construído por etapas, com foco no aprendizado de C#, .NET, APIs e testes automatizados.
