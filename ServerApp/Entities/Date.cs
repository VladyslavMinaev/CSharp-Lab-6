using System;

namespace ServerApp.Entities;

public class Date
{
    public string RoomName { get; set; }
    public DateTime DateTime { get; set; }
    public Guid? UserId { get; set; }
}