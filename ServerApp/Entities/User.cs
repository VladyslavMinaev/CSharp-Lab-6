using System;

namespace ServerApp.Entities;

public class User
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public Guid? Token { get; set; }
}