using KerridgeAsessment.Services;
using KerridgeAsessment.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KerridgeAsessment.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private readonly PlacesService _service;
        public HomeViewModel()
        {
            _service = new PlacesService();
            InitProperties();
        }

        public Command<string> SearchCommand { get; set; }
        private async Task ExecuteSearchCommand(string searchKey)
        {
            IsLoading = true;
            Message = "Searching...";
            var places = await _service.GetPlaceListItems(searchKey);
            var placeListViewModel = new PlaceListViewModel(places);
            var placeListPage = new PlaceListPage(placeListViewModel);
            await PushPage(placeListPage);
            IsLoading = false;
        }

        private void InitProperties()
        {
            SearchCommand = new Command<string>(async (key) => await ExecuteSearchCommand(key));
        }
    }
}
