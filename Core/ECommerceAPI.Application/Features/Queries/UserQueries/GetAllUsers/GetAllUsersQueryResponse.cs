namespace ECommerceAPI.Application.Features.Queries.UserQueries.GetAllUsers;

public class GetAllUsersQueryResponse
{
    public object Users { get; set; }
    public int TotalUsersCount { get; set; }
}