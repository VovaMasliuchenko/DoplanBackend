namespace Doplan.Data.Entities
{
    public class TaskToDo
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Id_User { get; set; }
        public User ToDoUser { get; set; }
        public bool IsCompleted { get; set; }
    }
}
