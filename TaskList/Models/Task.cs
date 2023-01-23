namespace TaskList.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime ExpectedDate { get; set; }
        public bool IsCompleted { get; set; }
        

        public Task()
        {
            Description= string.Empty;
            ExpectedDate = DateTime.Now;
            IsCompleted = false;
        }

        public Task(int id, string description, DateTime date) : this()
        {
            Id = id;
            Description = description;
            ExpectedDate = date;
        }
    }
}
