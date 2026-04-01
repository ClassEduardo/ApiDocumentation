namespace ApiDocumentation.OpenApi;

public static class ApiResponseMetadata
{
    public static string GetDefaultMessage(int statusCode) => statusCode switch
    {
        200 => "Operação realizada com sucesso.",
        201 => "Recurso criado com sucesso.",
        202 => "Requisição aceita e está em processamento.",
        204 => "Operação bem-sucedida, sem conteúdo para retornar.",
        _ => "Operação realizada com sucesso."
    };
}
