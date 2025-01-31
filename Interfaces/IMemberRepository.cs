using ClubManagementAPI.Models;

namespace ClubManagementAPI.Interfaces
{
    public interface IMemberRepository
    {
        Task<Member> GetMemberByNameAsync(string memberName);
    }
}
