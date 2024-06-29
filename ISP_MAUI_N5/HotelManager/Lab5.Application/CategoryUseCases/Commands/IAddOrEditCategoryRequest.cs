namespace Lab5.Application.CategoryUseCases.Commands
{
    public interface IAddOrEditCategoryRequest: IRequest
    {
        Category Category { get; set; }
    }
}