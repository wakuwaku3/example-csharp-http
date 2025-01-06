namespace Example.CSharp.Http.WebApi;

public interface IUserRepository
{
    IEnumerable<User> GetAll();
}
public class Repository : IUserRepository
{
    public IEnumerable<User> GetAll()
    {
        yield return new User { Id = new UserId(Guid.NewGuid()), Name = new UserName("Alice") };
        yield return new User { Id = new UserId(Guid.NewGuid()), Name = new UserName("Bob") };
        yield return new User { Id = new UserId(Guid.NewGuid()), Name = new UserName("Charlie") };
    }
}
