namespace Lab5.Application.RoomUseCases.Queries
{
    internal class GetRoomsByCategoryIdQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetRoomsByCategoryIdQuery, IEnumerable<Room>>
    {
        public async Task<IEnumerable<Room>> Handle(GetRoomsByCategoryIdQuery request, CancellationToken cancellationToken)
        {
            var a = await unitOfWork.RoomRepository.ListAsync(s => s.CategoryId.Equals(request.Id), cancellationToken);
            return a.Where(s => s.CategoryId == request.Id);
        }
    }
}