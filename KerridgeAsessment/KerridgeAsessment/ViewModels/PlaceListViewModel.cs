using KerridgeAsessment.Models;
using KerridgeAsessment.Services;
using KerridgeAsessment.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KerridgeAsessment.ViewModels
{
    public class PlaceListViewModel : BaseViewModel
    {
        private readonly PlacesService _service;
        public PlaceListViewModel(List<PlaceListItem> listItems)
        {
            Places = new ObservableCollection<PlaceListItem>(listItems);
            _service = new PlacesService();
            InitProperties();
        }

        public ObservableCollection<PlaceListItem> Places { get; set; }
        public Command<PlaceListItem> SelectedPlaceCommand { get; set; }
        private async Task ExecuteSelectedPlaceCommand(PlaceListItem item)
        {
            var place = await _service.GetPlaceItem(item.PlaceId);
            if (place == null)
            {
                await DisplayAlert("Error", $"Could not retrieve place: {item.MainText}", "Okay");
            }
            else
            {
                var placeItemViewModel = new PlaceViewModel(place);
                var page = new PlacePage(placeItemViewModel);
                await PushPage(page);
            }
        }

        private void InitProperties()
        {
            SelectedPlaceCommand = new Command<PlaceListItem>(async (item) => await ExecuteSelectedPlaceCommand(item));
        }
    }
}
