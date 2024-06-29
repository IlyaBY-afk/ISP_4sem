using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Lab5.Application.RoomUseCases.Commands;
using Lab5.Application.RoomUseCases.Queries;
using Lab5.UI.Pages.TaskPages;

namespace Lab5.UI.ViewModels
{
    [QueryProperty("Room", "Room")]
    public partial class ViewRoomViewModel(IMediator mediator): ObservableObject
    {
        [ObservableProperty] private Room room;
        [ObservableProperty] private string name;
        [ObservableProperty] private double serviceCost;
        [ObservableProperty] private string categoryId;
        [ObservableProperty] private DateTime checkInDate;
        [ObservableProperty] private DateTime checkOutDate;
        [ObservableProperty] private string imageSrc;

        [RelayCommand]
        async Task GetRoomById()
        {
            Room = await mediator.Send(new GetRoomByIdQuery(Room.Id));
            Name = Room.Name!;
            ServiceCost = Room.ServiceCost;
            CheckInDate = Room.CheckInDate;
            CheckOutDate = Room.CheckOutDate;
            ImageSrc = Room.ImageSrc;
        }

        [RelayCommand]
        async Task DeleteRoom()
        {
            await mediator.Send(new DeleteRoomRequest(Room));
            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        private async Task EditRoom()
        {
            await GotoAddOrEditPage(nameof(AddOrEditRoom), new EditRoomRequest { Room = Room });
        }

        private async Task GotoAddOrEditPage(string route, IRequest request)
        {
            IDictionary<string, object> parameters =
                new Dictionary<string, object>()
                {
                    { "Request", request },
                    { "Room", Room }
                };
            await Shell.Current.GoToAsync(route, parameters);
        }
    }
}
