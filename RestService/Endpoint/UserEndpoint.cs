using System.Text;
using RestService.Data;
using RestService.DatabaseDriver;
using RestService.DataMapper;
using RestService.Extensions;

namespace RestService.Endpoint;

public class UserEndpoint : IEndpoint<User>
{
    private IDatabaseDriver _driver;
    private IDataMapper<User> _mapper;

    private string _query = @"select ID, Username, Password from main.Users";

    public UserEndpoint(IDatabaseDriver driver, IDataMapper<User> mapper)
    {
        _driver = driver;
        _mapper = mapper;
    }

    public string Get() =>
        GetAsync()
            .WaitForResult()
            .Aggregate(
                seed: new StringBuilder(), 
                func: (builder, user) => builder.Append($"{user}{Environment.NewLine}"))
            .ToString();
    

    public async Task<User[]> GetAsync()
    {
        await using var enumerator = _driver.Read(_query, _mapper).GetAsyncEnumerator();

        var users = new List<User>();

        while (await enumerator.MoveNextAsync())
        {
            users.Add(enumerator.Current);
        }

        return users.ToArray();
    }
}