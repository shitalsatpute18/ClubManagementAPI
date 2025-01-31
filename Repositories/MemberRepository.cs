using ClubManagementAPI.Interfaces;
using ClubManagementAPI.Models;
using Microsoft.Data.SqlClient;
using System.Data;
using Dapper;

namespace ClubManagementAPI.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly string _connectionString;

        public MemberRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<Member> GetMemberByNameAsync(string memberName)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                var query = "SELECT * FROM Members WHERE Name = @MemberName";
                var member = await dbConnection.QuerySingleOrDefaultAsync<Member>(query, new { MemberName = memberName });

                return member;
            }
        }
    }
}
