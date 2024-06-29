namespace Lab5.Application.RoomUseCases.Queries
{
    public sealed record GetRoomByIdQuery(int Id): IRequest<Room>
    {

    }
}