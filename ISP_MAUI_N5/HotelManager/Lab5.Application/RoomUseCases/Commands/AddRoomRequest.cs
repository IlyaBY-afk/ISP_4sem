
namespace Lab5.Application.RoomUseCases.Commands
{
    public sealed class AddRoomRequest : IAddOrEditRoomRequest
    {
        public Room Room { get; set; }
    }
}