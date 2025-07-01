namespace Api.Models
{
    public class Tasks
    {
        public required string title { get; set; }
        public required string description { get; set; }
        public required string priority { get; set; }
        public required DateTime date { get; set; }
    }
}     
