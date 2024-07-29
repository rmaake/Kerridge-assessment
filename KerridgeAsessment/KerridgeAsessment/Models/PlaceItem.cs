using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KerridgeAsessment.Models
{
    public class PlaceItem
    {
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Url { get; set; }
        public string FormattedAddress { get; set; }
        public int UtcOffset { get; set; }

        public List<PlacePhotos> Photos { get; set; }
    }
}
