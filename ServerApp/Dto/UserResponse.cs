using ServerApp.Entities;

namespace ServerApp.Dto;

public class UserResponse
{
    public User User { get; set; }
    public int Code { get; set; }
}