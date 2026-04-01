using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi(options =>
{
    options.AddOperationTransformer((operation, context, cancellationToken) =>
    {
        ApiDocumentation.OpenApi.ProblemDetailsExamples.ApplyToOperation(operation);
        ApiDocumentation.OpenApi.SuccessResponseExamples.ApplyToOperation(operation);
        return System.Threading.Tasks.Task.CompletedTask;
    });
});
builder.Services.AddProblemDetails();
builder.Services.AddControllers(options =>
{
    options.Filters.Add<ApiDocumentation.Middleware.SuccessResponseFilter>();
});

var app = builder.Build();

app.UseMiddleware<ApiDocumentation.Middleware.ExceptionHandlingMiddleware>();

app.MapOpenApi();
app.MapScalarApiReference();
app.MapControllers();

app.UseHttpsRedirection();


app.Run();