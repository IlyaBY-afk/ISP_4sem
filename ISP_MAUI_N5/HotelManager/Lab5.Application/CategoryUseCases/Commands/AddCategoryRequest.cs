namespace Lab5.Application.CategoryUseCases.Commands
{
    public sealed class AddCategoryRequest: IAddOrEditCategoryRequest
    {
        public Category Category { get; set; }
    }
}