namespace Lab5.Application.RoomUseCases.Commands
{
    public class EditRoomRequest : IAddOrEditRoomRequest
    {
        public Room Room { get; set; }
    }
}