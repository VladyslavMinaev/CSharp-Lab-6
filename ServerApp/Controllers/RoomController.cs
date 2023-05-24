using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ServerApp.Entities;
using ServerApp.Utils;

namespace ServerApp.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class RoomController: ControllerBase
{
    private readonly FileManager _fileManager;
    private readonly string _usersFilePath = "Files/Users.json";
    private readonly string _roomsFilePath = "Files/Rooms.json";

    public RoomController()
    {
        _fileManager = new();
    }

    private User _checkToken(Guid? token)
    {
        var content = _fileManager.Read(_usersFilePath);
        var users = JsonConvert.DeserializeObject<List<User>>(content) ?? new List<User>();
        var currentUser = users.FirstOrDefault(u => u.Token == token);
        if (currentUser is null)
        {
            throw new UnauthorizedAccessException();
        }

        return currentUser;
    }

    [HttpPost]
    [Route("/api/[controller]/[action]")]
    public int Book(Guid? token, Date date)
    {
        var user = _checkToken(token);
        
        var content = _fileManager.Read(_roomsFilePath);
        var rooms = JsonConvert.DeserializeObject<List<Room>>(content) ?? new List<Room>();
        var room = rooms.FirstOrDefault(r => r.Name == date.RoomName);
        date.UserId = user.Id;
        room!.BookedDates.Add(date);
        
        var contentToWrite = JsonConvert.SerializeObject(rooms);
        _fileManager.Write(_roomsFilePath, contentToWrite);
        return 1;
    }

    [HttpGet]
    [Route("/api/[controller]/[action]")]
    public List<Room> GetFreeRooms(Guid? token, string dateTime)
    {
        _checkToken(token);

        var content = _fileManager.Read(_roomsFilePath);
        var rooms = JsonConvert.DeserializeObject<List<Room>>(content) ?? new List<Room>();

        return rooms.Where(r => !r.BookedDates.Exists(d => d.DateTime == DateTime.Parse(dateTime))).ToList();
    }
    
    [HttpGet]
    [Route("/api/[controller]/[action]")]
    public int GetPlacesByRoom(Guid? token, string roomName)
    {
        _checkToken(token);
        
        var content = _fileManager.Read(_roomsFilePath);
        var rooms = JsonConvert.DeserializeObject<List<Room>>(content) ?? new List<Room>();
        var room = rooms.FirstOrDefault(r => r.Name == roomName);

        return room!.PlacesAmount;
    }
    
    [HttpGet]
    [Route("/api/[controller]/[action]")]
    public double GetPriceByRoom(Guid? token, string roomName)
    {
        _checkToken(token);

        var content = _fileManager.Read(_roomsFilePath);
        var rooms = JsonConvert.DeserializeObject<List<Room>>(content) ?? new List<Room>();
        var room = rooms.FirstOrDefault(r => r.Name == roomName);

        return room!.Price;
    }

    [HttpGet]
    [Route("/api/[controller]/[action]")]
    public List<Date> GetMyBookings(Guid? token)
    {
        var user = _checkToken(token);
        
        List<Date> dates = new();
        
        var content = _fileManager.Read(_roomsFilePath);
        var rooms = JsonConvert.DeserializeObject<List<Room>>(content) ?? new List<Room>();

        foreach (var room in rooms)
        {
            var myDates = room.BookedDates.Where(d => d.UserId == user.Id);
            dates.AddRange(myDates);
        }

        return dates.OrderByDescending(d => d.DateTime).ToList();
    }
}