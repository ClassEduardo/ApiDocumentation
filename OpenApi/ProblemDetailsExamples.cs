using System;
using System.Text.Json.Nodes;

namespace ApiDocumentation.OpenApi;

public static class ProblemDetailsExamples
{
    /// <summary>
    /// Injeta dinamicamente os exemplos baseados no Status Code para as respostas da API.
    /// Para todos os File status, nós modificaremos o campo "Example" das MediaTypes.
    /// </summary>
    public static void ApplyToOperation(dynamic operation)
    {
        foreach (var response in operation.Responses)
        {
            string key = response.Key;

            // Ignoramos os status de sucesso
            if (key == "200" || key == "201" || key == "202" || key == "204")
                continue;

            if (int.TryParse(key, out int statusCode))
            {
                foreach (var mediaType in response.Value.Content)
                {
                    string mediaTypeKey = mediaType.Key;
                    
                    // Adicionar exemplos para retornos de erro ProblemDetails (json e plain)
                    if (mediaTypeKey.Contains("json") || mediaTypeKey.Contains("plain"))
                    {
                        var exampleJson = GetExampleForStatusCode(statusCode);
                        mediaType.Value.Example = JsonNode.Parse(exampleJson);
                    }
                }
            }
        }
    }

    private static string GetExampleForStatusCode(int statusCode)
    {
        var title = ProblemDetailsMetadata.GetTitle(statusCode);
        var typeUrl = ProblemDetailsMetadata.GetType(statusCode);
        var detail = ProblemDetailsMetadata.GetDefaultDetail(statusCode);

        return $$"""
        {
          "type": "{{typeUrl}}",
          "title": "{{title}}",
          "status": {{statusCode}},
          "detail": "{{detail}}",
          "instance": "/api/produto"
        }
        """;
    }
}
