using ISP_MAUI.ViewModels;

namespace ISP_MAUI.Views;

public partial class ProgressBar
{
    public ProgressBar(ProgressBarViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}