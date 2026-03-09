using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;

namespace ApiDocumentation.Controller;

[ApiController]
[Route("api/produto")]

public class ProdutoController : ControllerBase
{

    [HttpGet("{id:guid}")]
    [EndpointSummary("Busca de produto.")]
    [EndpointDescription("Recebe um route parameter Id que retorna um produto.")]
    [ProducesResponseType(StatusCodes.Status200OK, Description = "Produto é encontrado no banco")]
    [ProducesResponseType(StatusCodes.Status204NoContent, Description = "Coleção filtrada não encontrou produto")]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Description = "Usuário não logado ou token expirado")]
    [ProducesResponseType(StatusCodes.Status403Forbidden, Description = "Usuário logado sem permissão de criação.")]
    [ProducesResponseType(StatusCodes.Status404NotFound, Description = "Produto não encontrado")]
    public IActionResult Get([Description("Identificador único do produto para busca")] Guid id)
    {
        return Ok("Produto: X");
    }

    [HttpPost]
    [EndpointSummary("Criação de produtos.")]
    [EndpointDescription("Recebe um produto no body que será criado no banco.")]
    [ProducesResponseType(StatusCodes.Status201Created, Description = "Produto criado com sucesso.")]
    [ProducesResponseType(StatusCodes.Status202Accepted, Description = "Produto será criado futuramente no banco.")]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Description = "Falta de campo obrigatório.")]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Description = "Usuário não logado ou token expirado.")]
    [ProducesResponseType(StatusCodes.Status403Forbidden, Description = "Usuário logado sem permissão de criação.")]
    [ProducesResponseType(StatusCodes.Status409Conflict, Description = "Objeto já criado ou conflito de campo")]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Description = "Objeto não aprovado nas regras de negócio")]
    public IActionResult Create(
        [Description("Produto que será criado no banco.")]
        [FromBody] ProdutoDto produtoDto)
    {
        return Ok("produto criado");
    }

    [HttpPatch("{id:guid}")]
    [EndpointSummary("Atualização de produtos.")]
    [EndpointDescription("Recebe um route parameter Id e campos no body que serão utilizados para atualizar o produto no banco.")]
    [ProducesResponseType(StatusCodes.Status200OK, Description = "Produto atualizado com sucesso")]
    [ProducesResponseType(StatusCodes.Status204NoContent, Description = "Atualização feita sem retornar body.")]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Description = "Payload inválido.")]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Description = "Usuário não logado ou token expirado.")]
    [ProducesResponseType(StatusCodes.Status403Forbidden, Description = "Usuário logado sem permissão de update.")]
    [ProducesResponseType(StatusCodes.Status404NotFound, Description = "produto não encontrado para atualização.")]
    [ProducesResponseType(StatusCodes.Status409Conflict, Description = "Conflito com ao tentar atualizar produto.")]
    public IActionResult Update(
        [Description("Identificador único do produto para atualização")] Guid id,
        [Description("Produto que será atualizado no banco.")]
        [FromBody] ProdutoDto produtoDto)
    {
        return Ok("produto X atualizado");
    }

    [HttpDelete("{id:guid}")]
    [EndpointSummary("Exclusão de produtos.")]
    [EndpointDescription("Recebe um route parameter Id e exclui o produto do banco.")]
    [ProducesResponseType(StatusCodes.Status200OK, Description = "Objeto excluído e retorno de informação como true ou false")]
    [ProducesResponseType(StatusCodes.Status202Accepted, Description = "Exclusão aceita mas ocorre de forma assíncrona.")]
    [ProducesResponseType(StatusCodes.Status204NoContent, Description = "Objeto excluído mas sem retornar informação")]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Description = "Usuário não logado ou token expirado.")]
    [ProducesResponseType(StatusCodes.Status403Forbidden, Description = "Usuário logado sem permissão de exclusão.")]
    [ProducesResponseType(StatusCodes.Status404NotFound, Description = "Objeto não encontrado para exclusão")]
    public IActionResult Delete([Description("Identificador único do produto para exclusão")] Guid id)
    {
        return Ok("produto X excluído");
    }
}

public class ProdutoDto
{
    [Description("Nome do produto a ser criado.")]
    public string Nome { get; set; } = string.Empty;

    [Description("Nome disponível do produto.")]
    public int Qntd { get; set; }
}