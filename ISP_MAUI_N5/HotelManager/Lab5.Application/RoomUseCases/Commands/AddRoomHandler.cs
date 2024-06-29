namespace Lab5.Application.RoomUseCases.Commands
{
    public class AddRoomHandler(IUnitOfWork unitOfWork): IRequestHandler<AddRoomRequest>
    {
        public async Task Handle(AddRoomRequest request, CancellationToken cancellationToken)
        {
            await unitOfWork.RoomRepository.AddAsync(request.Room, cancellationToken);
            await unitOfWork.SaveAllAsync();
        }
    }
}