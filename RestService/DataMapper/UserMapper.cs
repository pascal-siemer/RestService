using System.Data;
using RestService.Data;

namespace RestService.DataMapper;

public class UserMapper : IDataMapper<User>
{
        public User Map(IDataRecord data) => new User(
            data.GetInt32(0),
            data.GetString(1), 
            data.GetString(2));
}