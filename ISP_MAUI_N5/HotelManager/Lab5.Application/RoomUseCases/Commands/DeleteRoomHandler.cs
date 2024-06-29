namespace Lab5.Application.RoomUseCases.Commands
{
    public class DeleteRoomHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteRoomRequest>
    {
        public async Task Handle(DeleteRoomRequest request, CancellationToken cancellationToken)
        {
            await unitOfWork.RoomRepository.DeleteAsync(request.Room);
            await unitOfWork.SaveAllAsync();
        }
    }
}