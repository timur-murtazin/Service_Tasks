namespace Service_Tasks.DAL.Entities
{
    public class TaskEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string Status { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
