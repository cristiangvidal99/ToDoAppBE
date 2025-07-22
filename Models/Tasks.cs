namespace Api.Models
{
    public class Tasks
    {
        public string ?id { get; set; }
        public required string title { get; set; }
        public required string description { get; set; }
        public required string priority { get; set; }
        public required DateTime date { get; set; }
    }
    public class CreateTask
    {
        public required string title { get; set; }
        public required string description { get; set; }
        public required string priority { get; set; }
        public required DateTime date { get; set; }
    }
}     
