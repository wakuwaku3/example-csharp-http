using Example.CSharp.Http.WebApi;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<GetUseCase>();
builder.Services.AddTransient<IUserRepository, Repository>();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapGet("/users", (GetUseCase usecase) =>
{
    return usecase.Execute();
});
app.Run();

public partial class Program { }
