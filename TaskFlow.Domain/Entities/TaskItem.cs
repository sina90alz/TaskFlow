namespace TaskFlow.Domain.Entities
{
    public class TaskItem
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = string.Empty;
        public string Status { get; set; } = "New";

        // Foreign Key to User
        public Guid? UserId { get; set; }
        public User? AssignedUser { get; set; }
    }
}
