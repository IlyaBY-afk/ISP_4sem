using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Lab5.Application.RoomUseCases.Commands;

namespace Lab5.UI.ViewModels
{
    public partial class AddOrEditRoomViewModel(IMediator mediator) : ObservableObject, IQueryAttributable
    {
        private IAddOrEditRoomRequest _request;

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            _request = query["Request"] as IAddOrEditRoomRequest;
            if (_request != null)
            {
                ServiceCost = _request.Room.ServiceCost;
                ImageSrc = _request.Room.ImageSrc;
                Name = _request.Room.Name;
            }

            if (_request?.Room.CheckInDate.Equals(new DateTime()) == true)
            {
                CheckInDate = DateTime.Today;
                CheckOutDate = DateTime.Today;
            }
        }

        [ObservableProperty] private double serviceCost;
        [ObservableProperty] private string imageSrc;
        [ObservableProperty] private string name;
        [ObservableProperty] private DateTime checkInDate;
        [ObservableProperty] private DateTime checkOutDate;

        [RelayCommand]
        async Task AddOrEditRoom()
        {
            _request.Room.Name = Name;
            _request.Room.CheckInDate = CheckInDate;
            _request.Room.CheckOutDate = CheckOutDate;
            _request.Room.ImageSrc = ImageSrc;
            _request.Room.ServiceCost = Convert.ToDouble(ServiceCost);
            await mediator.Send(_request);
            await GoBack();
        }

        [RelayCommand]
        async Task SelectImage()
        {
            var result = await FilePicker.PickAsync(new PickOptions
            {
                FileTypes = FilePickerFileType.Images
            });
            var fullPath = result?.FullPath;
            if (fullPath != null)
            {
                ImageSrc = fullPath;
            }
        }

        [RelayCommand]
        async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        void UpdateServiceCost(double value)
        {
            var tmp = value;
            ServiceCost = Convert.ToDouble(tmp);
        }
    }
}
