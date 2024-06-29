using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Lab5.Application.CategoryUseCases.Commands;
using Lab5.Application.CategoryUseCases.Queries;
using Lab5.Application.RoomUseCases.Commands;
using Lab5.Application.RoomUseCases.Queries;
using MediatR;
using System.Collections.ObjectModel;
using Lab5.Domain.Entities;
using Lab5.UI.Pages.TaskPages;

namespace Lab5.UI.ViewModels
{
    public partial class ViewCategoryViewModel(IMediator mediator): ObservableObject
    {
        [ObservableProperty] Category? selectedCategory;

        public ObservableCollection<Category> ListOfCategories { get; set; } = [];

        public ObservableCollection<Room> ListOfRooms { get; } = [];

        [RelayCommand]
        async Task LoadCategories()
        {
            if (SelectedCategory != null) return;
            await GetCategories();
        }

        [RelayCommand]
        async Task UpdateSelectedCategory(Category selected) => await GetRooms(selected);

        [RelayCommand]
        async Task UpdateRooms() => await GetRooms(SelectedCategory);

        private async Task GetCategories()
        {
            ListOfCategories.Clear();
            ListOfRooms.Clear();
            var categories = await mediator.Send(new GetCategoryQuery());
            foreach (var i in categories)
            {
                ListOfCategories.Add(i);
            }
        }

        private async Task GetRooms(Category? selected)
        {
            ListOfRooms.Clear();
            if (selected != null)
            {
                var list = await mediator.Send(new GetRoomsByCategoryIdQuery(selected.Id));
                foreach (var room in list)
                {
                    ListOfRooms.Add(room);
                }
            }
        }

        [RelayCommand]
        private async Task GoToRoom(Room selectedRoom) => await GoToRoomPage(selectedRoom);

        private async Task GoToRoomPage(Room room)
        {
            IDictionary<string, object> parameters =
                new Dictionary<string, object>()
                {
                    { "Room", room }
                };
            await Shell.Current.GoToAsync(nameof(ViewRoom), parameters);
        }


        private async Task GotoAddOrEditPage(string route, IRequest request)
        {
            IDictionary<string, object> parameters =
                new Dictionary<string, object>()
                {
                { "Request", request }
                };
            await Shell.Current.GoToAsync(route, parameters);
        }

        [RelayCommand]
        private async Task AddRoom()
        {
            if (SelectedCategory != null)
            {
                await GotoAddOrEditPage(nameof(AddOrEditRoom),
                    new AddRoomRequest { Room = new Room { CategoryId = SelectedCategory.Id } });
                await GetRooms(SelectedCategory);
            }
        }

        [RelayCommand]
        private async Task AddCategory()
        {
            await GotoAddOrEditPage(nameof(AddOrEditCategory), new AddCategoryRequest() { Category = new Category() });
            await GetCategories();
        }

        [RelayCommand]
        private async Task EditCategory()
        {
            if (SelectedCategory == null) return;
            await GotoAddOrEditPage(nameof(AddOrEditCategory), new EditCategoryRequest { Category = SelectedCategory });
            await GetCategories();
        }

        [RelayCommand]
        private async Task DeleteCategory()
        {
            if (SelectedCategory == null) return;
            await mediator.Send(new DeleteCategoryRequest(SelectedCategory));
            await GetCategories();
        }
    }
}