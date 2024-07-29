using KerridgeAsessment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace KerridgeAsessment.Services
{
    public class PlacesService: BaseService
    {
        public async Task<List<PlaceListItem>> GetPlaceListItems(string searchKey)
        {
            var urlEnconded = UrlEncoder.Default.Encode(searchKey);
            var response = await Get<List<PlaceListItem>>($"api/v1/locations/places?criteria={urlEnconded}");
            return response.Data;
        }

        public async Task<PlaceItem> GetPlaceItem(string placeId)
        {
            var urlEnconded = UrlEncoder.Default.Encode(placeId);
            var response = await Get<PlaceItem>($"api/v1/locations/places/{urlEnconded}");
            return response.Data;
        }

        public async Task<PlacePhoto> GetImage(string photoId)
        {
            var urlEnconded = UrlEncoder.Default.Encode(photoId);
            var response = await Get<PlacePhoto>($"api/v1/locations/photos/{urlEnconded}");
            return response.Data;
        }
    }
}
