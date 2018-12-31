namespace SchedulingSystem.Models
{
    public class RoomRoomType
    {
        public Room Room { get; set; }
        public RoomType RoomType { get; set; }
        public int RoomId { get; set; }
        public int RoomTypeId { get; set; }
    }
}