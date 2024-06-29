namespace Lab5.Application.CategoryUseCases.Commands
{
    internal class AddCategoryHandler(IUnitOfWork unitOfWork): IRequestHandler<AddCategoryRequest>
    {
        public async Task Handle(AddCategoryRequest request, CancellationToken cancellationToken)
        {
            await unitOfWork.CategoryRepository.AddAsync(request.Category, cancellationToken);
            await unitOfWork.SaveAllAsync();
        }
    }
}