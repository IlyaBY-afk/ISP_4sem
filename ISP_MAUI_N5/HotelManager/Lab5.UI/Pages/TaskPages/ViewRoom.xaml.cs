namespace Lab5.UI.Pages.TaskPages;

public partial class ViewRoom : ContentPage
{
	public ViewRoom(ViewModels.ViewRoomViewModel viewRoomViewModel)
	{
		InitializeComponent();
        BindingContext = viewRoomViewModel;
    }
}