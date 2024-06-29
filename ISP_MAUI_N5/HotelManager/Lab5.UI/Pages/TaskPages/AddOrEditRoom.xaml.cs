using Lab5.UI.ViewModels;

namespace Lab5.UI.Pages.TaskPages
{
	public partial class AddOrEditRoom : ContentPage
	{
		public AddOrEditRoom(AddOrEditRoomViewModel viewModel)
		{
			InitializeComponent();
			BindingContext = viewModel;
		}
	}
}