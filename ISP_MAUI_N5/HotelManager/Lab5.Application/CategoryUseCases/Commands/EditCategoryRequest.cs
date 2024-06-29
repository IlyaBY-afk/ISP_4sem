namespace Lab5.Application.CategoryUseCases.Commands
{
    public class EditCategoryRequest: IAddOrEditCategoryRequest
    {
        public Category Category { get; set; }
    }
}