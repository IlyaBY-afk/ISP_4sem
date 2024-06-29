using Lab5.UI.Pages.TaskPages;

namespace Lab5.UI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ViewRoom), typeof(ViewRoom));
            Routing.RegisterRoute(nameof(AddOrEditCategory), typeof(AddOrEditCategory));
            Routing.RegisterRoute(nameof(AddOrEditRoom), typeof(AddOrEditRoom));
        }
    }
}
