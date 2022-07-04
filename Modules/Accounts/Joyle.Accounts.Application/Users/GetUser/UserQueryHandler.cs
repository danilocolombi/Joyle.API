using Dapper;
using Joyle.BuildingBlocks.Application.Data;
using Joyle.BuildingBlocks.Application.Messages;
using System.Threading;
using System.Threading.Tasks;

namespace Joyle.Accounts.Application.Users.GetUser
{
    public class UserQueryHandler : IQueryHandler<GetUserQuery, UserDto>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public UserQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<UserDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var sql = $@"SELECT Username AS {nameof(UserDto.Username)},
                        FullName AS {nameof(UserDto.FullName)},
                        Email AS {nameof(UserDto.Email)},
                        IsActive AS {nameof(UserDto.IsActive)}
                        FROM dbo.JoyleUser
                        WHERE id = @userId";

            var connection = _sqlConnectionFactory.GetOpenConnection();

           var user = await connection.QueryFirstOrDefaultAsync<UserDto>(sql, new { userId = request.UserId });

            return user;
        }
    }
}
