using application.Processamento;
using Domain.Classificacao;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PedidosController : ControllerBase
{
    private readonly CatalogoProcessadores _catalogo;

    public PedidosController(CatalogoProcessadores catalogo)
    {
        _catalogo = catalogo;
    }

    [HttpGet("processar-teste")]
    public ActionResult<string> ProcessarTeste()
    {
        Guid pedidoId = Guid.NewGuid();
        decimal valorTotal = 150m;
        int quantidadeItens = 2;
        string regiao = "Sudeste";
        bool prioritario = false;

        CategoriaProcessamento categoria =
            ClassificadorPedido.Classificar(
                valorTotal,
                quantidadeItens,
                regiao,
                prioritario);

        IProcessadorPedido processador =
            _catalogo.Obter(categoria, 1);

        string resultado =
            processador.Processar(pedidoId, valorTotal);

        return Ok(resultado);
    }
}
