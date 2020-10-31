using Dapper;
using DataAccess.Entities;
using DataAccess.Factories;
using DataAccess.Repositories.Interfaces;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private IConnectionFactory connectionFactory;
        public UserRepository(IConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public async Task<UserDetails> GetUserDetails(long Userid)
        {
            UserDetails userDetails = null;
            string query = $@"Select Id as Userid,Name from testing";
            using (var conn=this.connectionFactory.Connection)
            {
                userDetails = await conn.QuerySingleOrDefaultAsync<UserDetails>(query,new { userid=Userid});
            }
            return userDetails;
        }

    }
}
