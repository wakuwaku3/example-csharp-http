namespace Example.CSharp.Http.WebApi;

public record User
{
    public required UserId Id { get; init; }
    public required UserName Name { get; init; }
}

public record UserId(Guid Value);
public record UserName(string Value);
