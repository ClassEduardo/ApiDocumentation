using System.Collections.Generic;

namespace ApiDocumentation.OpenApi;

public static class ProblemDetailsMetadata
{
    public static string GetTitle(int statusCode) => statusCode switch
    {
        400 => "Bad Request",
        401 => "Unauthorized",
        403 => "Forbidden",
        404 => "Not Found",
        409 => "Conflict",
        422 => "Unprocessable Entity",
        _ => "Internal Server Error"
    };

    public static string GetType(int statusCode) => statusCode switch
    {
        400 => "https://tools.ietf.org/html/rfc9110#section-15.5.1",
        401 => "https://tools.ietf.org/html/rfc9110#section-15.5.2",
        403 => "https://tools.ietf.org/html/rfc9110#section-15.5.4",
        404 => "https://tools.ietf.org/html/rfc9110#section-15.5.5",
        409 => "https://tools.ietf.org/html/rfc9110#section-15.5.10",
        422 => "https://tools.ietf.org/html/rfc4918#section-11.2",
        _ => "https://tools.ietf.org/html/rfc9110#section-15.6.1"
    };

    public static string GetDefaultDetail(int statusCode) => statusCode switch
    {
        400 => "Falta de campo obrigatório ou formato incorreto.",
        401 => "Usuário não logado ou token expirado.",
        403 => "Usuário logado sem permissão para esta ação.",
        404 => "O objeto buscado não foi encontrado no banco.",
        409 => "Conflito ao tentar processar a solicitação (ex: objeto já existente).",
        422 => "Entidade não pôde ser processada devido a regras de negócio.",
        _ => "Ocorreu um erro inesperado no processamento da sua solicitação."
    };
}
