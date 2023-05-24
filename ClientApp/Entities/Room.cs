using System.Collections.Generic;

namespace ClientApp.Entities;

public class Room
{
    public string Name { get; set; }
    public int PlacesAmount { get; set; }
    public double Price { get; set; }
    public List<Date> BookedDates { get; set; }
}