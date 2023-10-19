namespace project_be.Models
{
    public class ExternalApiResponse<T>
    {
        public bool Error { get; set; }
        public string Msg { get; set; }
        public List<T> Data { get; set; }
    }
}
