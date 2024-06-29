namespace Lab5.Application.RoomUseCases.Commands
{
    public interface IAddOrEditRoomRequest: IRequest
    {
        Room Room { get; set; }
    }
}