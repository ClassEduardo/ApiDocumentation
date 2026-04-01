using System.Text.Json.Nodes;

namespace ApiDocumentation.OpenApi;

public static class SuccessResponseExamples
{
    public static void ApplyToOperation(dynamic operation)
    {
        foreach (var response in operation.Responses)
        {
            string key = response.Key;

            if (key != "200" && key != "201" && key != "202" && key != "204")
                continue;

            if (int.TryParse(key, out int statusCode))
            {
                if (response.Value.Content.Count == 0)
                {
                    var contentObj = new Microsoft.OpenApi.Models.OpenApiMediaType();
                    response.Value.Content.Add("application/json", contentObj);
                }

                foreach (var mediaType in response.Value.Content)
                {
                    string mediaTypeKey = mediaType.Key;
                    
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
        var message = ApiResponseMetadata.GetDefaultMessage(statusCode);
        
        return $$"""
        {
          "success": true,
          "message": "{{message}}",
          "statusCode": {{statusCode}},
          "data": "Objeto ou payload retornado pelo Controller (ex: ProdutoDto)"
        }
        """;
    }
}
