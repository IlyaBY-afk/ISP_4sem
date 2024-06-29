namespace Lab5.Application.CategoryUseCases.Commands
{
    internal class EditCategoryHandler(IUnitOfWork unitOfWork) : IRequestHandler<EditCategoryRequest>
    {
        public async Task Handle(EditCategoryRequest request, CancellationToken cancellationToken)
        {
            await unitOfWork.CategoryRepository.UpdateAsync(request.Category, cancellationToken);
            await unitOfWork.SaveAllAsync();
        }
    }
}