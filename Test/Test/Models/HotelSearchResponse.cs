namespace Test.Models
{
    public class HotelSearchResponse
    {
        public int hotelCode { get; set; }

        public string hotelName { get; set; }

        public double totalRate { get; set; }

        public string address { get; set; }

        public string starLevel { get; set; }

        public string hotelMainImage { get; set; }

        public string policiesAndDisclaimer { get; set; }

        public string hotelDescriptions { get; set; }

        public double longitude { get; set; }

        public double latitude { get; set; }

        public string currency { get; set; }
    }
}
