using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ServerApp.Dto;
using ServerApp.Entities;
using ServerApp.Utils;

namespace ServerApp.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class LoginController : ControllerBase
{
    private readonly FileManager _fileManager;
    private readonly string _usersFilePath = "Files/Users.json";

    public LoginController()
    {
        _fileManager = new();
    }

    [HttpPost]
    public UserResponse Login(User user)
    {
        var content = _fileManager.Read(_usersFilePath);
        var users = JsonConvert.DeserializeObject<List<User>>(content) ?? new List<User>();
        var currentUser = users.FirstOrDefault(u => u.Email == user.Email);
        string contentToWrite;

        if (currentUser is null)
        {
            User newUser = new()
            {
                Id = Guid.NewGuid(),
                Password = user.Password,
                Email = user.Email,
                Token = Guid.NewGuid()
            };
            users.Add(newUser);
            contentToWrite = JsonConvert.SerializeObject(users);
            _fileManager.Write(_usersFilePath, contentToWrite);
            return new()
            {
                User = newUser,
                Code = 0
            };
        }

        if (currentUser.Password != user.Password)
        {
            return new()
            {
                User = null,
                Code = -1
            };
        }

        currentUser.Token = Guid.NewGuid();
        contentToWrite = JsonConvert.SerializeObject(users);
        _fileManager.Write(_usersFilePath, contentToWrite);

        return new()
        {
            User = currentUser,
            Code = 1
        };
    }
}