
namespace Lab5.Application.RoomUseCases.Commands
{
    public class EditRoomHandler(IUnitOfWork unitOfWork) : IRequestHandler<EditRoomRequest>
    {
        public async Task Handle(EditRoomRequest request, CancellationToken cancellationToken)
        {
            await unitOfWork.RoomRepository.UpdateAsync(request.Room, cancellationToken);
            await unitOfWork.SaveAllAsync();
        }
    }
}