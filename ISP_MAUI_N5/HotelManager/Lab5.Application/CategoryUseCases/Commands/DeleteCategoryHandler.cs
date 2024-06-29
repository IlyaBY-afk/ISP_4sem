namespace Lab5.Application.CategoryUseCases.Commands
{
    internal class DeleteCategoryHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteCategoryRequest>
    {
        public async Task Handle(DeleteCategoryRequest request, CancellationToken cancellationToken)
        {
            await unitOfWork.CategoryRepository.DeleteAsync(request.Category, cancellationToken);
            await unitOfWork.SaveAllAsync();
        }
    }
}