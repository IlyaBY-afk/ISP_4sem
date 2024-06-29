using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Lab5.Application.CategoryUseCases.Commands;

namespace Lab5.UI.ViewModels
{
    public partial class AddOrEditCategoryViewModel(IMediator mediator): ObservableObject, IQueryAttributable
    {
        private IAddOrEditCategoryRequest _request;

        [ObservableProperty] private string name;
        [ObservableProperty] private string description;

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            _request = query["Request"] as IAddOrEditCategoryRequest;
            if (_request == null) return;
            Name = _request.Category.Name;
            Description = _request.Category.Description;
        }

        [RelayCommand]
        async Task AddOrEditCategory()
        {
            _request.Category.Name = Name;
            _request.Category.Description = Description;
            await mediator.Send(_request);
            await GoBack();
        }

        [RelayCommand]
        async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}