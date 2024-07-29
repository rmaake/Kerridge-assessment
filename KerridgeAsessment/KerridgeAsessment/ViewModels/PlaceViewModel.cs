using KerridgeAsessment.Models;
using KerridgeAsessment.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KerridgeAsessment.ViewModels
{
    public class PlaceViewModel : BaseViewModel
    {
        private PlaceItem placeItem;
        private byte[] imageData;
        private readonly PlacesService _service;
        public PlaceViewModel(PlaceItem item)
        {
            placeItem = item;
            _service = new PlacesService();
            DownloadImage();
        }

        public PlaceItem PlaceItem 
        {
            get { return placeItem; }
        }

        public byte[] ImageData 
        { 
            get => imageData; 
            set => SetProperty(ref imageData, value); 
        }

        private async void DownloadImage()
        {
            var photoId = PlaceItem.Photos.FirstOrDefault(opt=>opt.Height >= 1080);
            if (photoId != null)
            {
                IsLoading = true;
                Message = "Loading Image...";
                var photo = await _service.GetImage(photoId.PhotoId);
                ImageData = Convert.FromBase64String(photo.Photo);
                IsLoading = false;
            }
            
        }
    }
}
