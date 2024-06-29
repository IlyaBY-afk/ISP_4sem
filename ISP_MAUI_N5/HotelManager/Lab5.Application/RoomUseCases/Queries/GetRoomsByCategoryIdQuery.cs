namespace Lab5.Application.RoomUseCases.Queries
{
    public sealed record GetRoomsByCategoryIdQuery(int Id): IRequest<IEnumerable<Room>>
    {

    }
}