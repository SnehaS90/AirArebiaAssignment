namespace Test.Models
{
    public class Response
    {
        public List<object> errors { get; set; }
        public Result result { get; set; }         
    }

    public class Result
    {
        public List<HotelSearchResponse> hotelSearchResponse { get; set; }
    }
}
