namespace DAL.Entities
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime DateCreate { get; set; }
        public DateTime DateExpectedEnd { get; set; }
        public DateTime? DateEnd { get; set; }
        public int CategoryId { get; set; }
        public int PersonId { get; set; }
    }
}
