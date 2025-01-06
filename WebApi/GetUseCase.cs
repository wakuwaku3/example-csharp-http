using System.Text.Json.Serialization;

namespace Example.CSharp.Http.WebApi;

public class GetUseCase(IUserRepository userRepository)
{
    public record Result
    {
        [JsonPropertyName("name")]
        public required string Name { get; init; }
    }

    public IEnumerable<Result> Execute()
    {
        return userRepository.GetAll().Select(user => new Result { Name = user.Name.Value });
    }
}
