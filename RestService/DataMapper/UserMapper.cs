using System.Data;
using RestService.Data;

namespace RestService.DataMapper;

public class UserMapper : IDataMapper<User>
{
    public User Map(IDataRecord data) => new User(
        ID: data.GetInt32(0),
        Username: data.GetString(1), 
        Password: data.GetString(2));
}