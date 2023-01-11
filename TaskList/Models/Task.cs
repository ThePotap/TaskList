namespace TaskList.Models
{
    public class Task
    {
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public bool IsCompleted { get; set; }

        public Task()
        {
            Description= string.Empty;
            Date = DateTime.Now;
            IsCompleted = false;
        }

        public Task(string description, DateTime date)
        {
            Description = description;
            Date = date;
            IsCompleted = false;
        }
    }
}
