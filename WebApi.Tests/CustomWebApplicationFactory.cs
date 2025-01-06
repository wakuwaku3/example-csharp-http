using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace Example.CSharp.Http.WebApi.Tests;

public class CustomWebApplicationFactory : WebApplicationFactory<Program>
{
    public Mock<IUserRepository>? UserRepositoryMock { get; init; }
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            if (UserRepositoryMock is not null)
            {
                // 既存のサービスを削除
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType == typeof(IUserRepository));
                if (descriptor != null)
                {
                    services.Remove(descriptor);
                }

                services.AddSingleton(UserRepositoryMock.Object);
            }
        });
    }
}
