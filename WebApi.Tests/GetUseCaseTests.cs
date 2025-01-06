using System.Net;
using FluentAssertions;
using Moq;

namespace Example.CSharp.Http.WebApi.Tests;

[TestFixture]
public class GetUseCaseTests
{
    [Test]
    public async Task ShouldSuccess()
    {
        // Arrange
        await using var factory = new CustomWebApplicationFactory();
        using var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/users");
        var content = await response.Content.ReadAsStringAsync();

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        content.Should().Be(JsonHelper.NormalizeJson("""
            [
                { "name": "Alice" },
                { "name": "Bob" },
                { "name": "Charlie" }
            ]
        """));
    }

    [Test]
    public async Task ShouldSuccessWithMock()
    {
        // Arrange
        var mockRepository = new Mock<IUserRepository>();
        await using var factory = new CustomWebApplicationFactory() { UserRepositoryMock = mockRepository };
        using var client = factory.CreateClient();

        mockRepository.Setup(x => x.GetAll()).Returns(
        [
            new User { Id = new UserId(Guid.NewGuid()), Name = new UserName("Alice") },
            new User { Id = new UserId(Guid.NewGuid()), Name = new UserName("Bob") },
        ]);

        // Act
        var response = await client.GetAsync("/users");
        var content = await response.Content.ReadAsStringAsync();

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        content.Should().Be(JsonHelper.NormalizeJson("""
            [
                { "name": "Alice" },
                { "name": "Bob" }
            ]
        """));
    }
}
