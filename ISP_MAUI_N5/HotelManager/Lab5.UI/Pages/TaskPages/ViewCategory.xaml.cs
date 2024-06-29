using Lab5.UI.ViewModels;

namespace Lab5.UI.Pages.TaskPages;

public partial class ViewCategory : ContentPage
{
	public ViewCategory(ViewCategoryViewModel viewCategoryViewModel)
	{
		InitializeComponent();
        BindingContext = viewCategoryViewModel;
    }
}