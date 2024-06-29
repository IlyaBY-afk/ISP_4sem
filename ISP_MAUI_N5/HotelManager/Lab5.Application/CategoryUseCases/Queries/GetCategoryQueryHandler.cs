namespace Lab5.Application.CategoryUseCases.Queries
{
    internal class GetCategoryQueryHandler(IUnitOfWork unitOfWork): IRequestHandler<GetCategoryQuery, IEnumerable<Category>>
    {
        public async Task<IEnumerable<Category>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            return await unitOfWork.CategoryRepository.ListAllAsync(cancellationToken);
        }
    }
}