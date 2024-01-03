namespace Azil.Gateway.DTOs.AnimalUser
{
    public class ResponseData
    {
        public string Id { get; set; }
        public int user_id { get; set; }
        public int anima_id { get; set; }
        public DateTime date_of_taking { get; set; }
    }

    public class DataListDto
    {
        public List<ResponseData> Data { get; set; }
    }

    public class AnimalUserDto
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public DataListDto Data { get; set; }
    }

    public class DataDto
    {
        public ResponseData Data { get; set; }
    }

    public class AnimalUserResponseDto
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public DataDto Data { get; set; }
    }
}
