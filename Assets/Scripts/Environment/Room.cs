using System.Collections.Generic;
using UnityEngine;

public class Room
{
    public int Width { get; private set; }
    public int Height { get; private set; }
    public Vector2Int Position { get; private set; }

    public Room(int width, int height, Vector2Int position)
    {
        Width = width;
        Height = height;
        Position = position;
    }
}

public class Level
{
    public List<Room> Rooms { get; private set; }

    public Level()
    {
        Rooms = new List<Room>();
    }

    public void AddRoom(Room room)
    {
        Rooms.Add(room);
    }
}