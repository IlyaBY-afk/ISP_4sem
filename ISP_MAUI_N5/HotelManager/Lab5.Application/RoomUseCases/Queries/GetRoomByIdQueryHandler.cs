namespace Lab5.Application.RoomUseCases.Queries
{
    internal class GetRoomByIdQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetRoomByIdQuery, Room>
    {
        public async Task<Room> Handle(GetRoomByIdQuery request, CancellationToken cancellationToken)
        {
            return await unitOfWork.RoomRepository.FirstOrDefaultAsync(r => r.Id == request.Id, cancellationToken);
        }
    }
}