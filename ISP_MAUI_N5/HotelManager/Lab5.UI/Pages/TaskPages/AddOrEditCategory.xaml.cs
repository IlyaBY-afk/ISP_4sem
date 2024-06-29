using Lab5.UI.ViewModels;

namespace Lab5.UI.Pages.TaskPages;

public partial class AddOrEditCategory : ContentPage
{
	public AddOrEditCategory(AddOrEditCategoryViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}