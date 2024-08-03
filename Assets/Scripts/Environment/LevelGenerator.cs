using System.Linq;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject roomPrefab;
    [Space]
    [SerializeField] private int numberOfRooms = 10;
    [SerializeField] private int roomWidthMin = 4;
    [SerializeField] private int roomWidthMax = 8;
    [SerializeField] private int roomHeightMin = 4;
    [SerializeField] private int roomHeightMax = 8;

    private Level _level;

    private void Start()
    {
        _level = new Level();
        GenerateRooms();
    }

    private void GenerateRooms()
    {
        for (int i = 0; i < numberOfRooms; i++)
        {
            int width = Random.Range(roomWidthMin, roomWidthMax);
            int height = Random.Range(roomHeightMin, roomHeightMax);
            Vector2Int position;

            bool overlaps;
            do
            {
                position = new Vector2Int(Random.Range(0, 50), 2);
                overlaps = _level.Rooms.Any(r => IsOverlapping(r, new Room(width, height, position)));
            } while (overlaps);

            Room room = new Room(width, height, position);
            _level.AddRoom(room);

            GameObject roomInstance = Instantiate(roomPrefab, new Vector3(position.x, position.y, 0), Quaternion.identity);
            roomInstance.transform.localScale = new Vector3(width, height, 1);
        }
    }
    private bool IsOverlapping(Room a, Room b)
    {
        return a.Position.x < b.Position.x + b.Width &&
               a.Position.x + a.Width > b.Position.x &&
               a.Position.y < b.Position.y + b.Height &&
               a.Position.y + a.Height > b.Position.y;
    }
}
