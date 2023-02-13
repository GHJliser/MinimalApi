using MinimalApi.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<CommandLoader>();
builder.Services.AddSingleton<ICommandService, CommandPromptService>();

var app = builder.Build();

app.MapGet("/", async (ICommandService service) =>
{
    try
    {
        await service.ExecuteAsync("ExcuteBat");
        return Results.Ok();
    }
    catch (Exception ex)
    {
        return Results.Problem(ex.ToString());
    }
});

app.Run();
