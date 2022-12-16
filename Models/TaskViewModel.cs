namespace ToDoList1.Models
{
    public class TaskViewModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int? Status { get; set; }
        public DateTime ToDoDate { get; set; }
    }
}
