namespace WebAPI.Models
{
    public class ChildModel
    {
        public int NumChild { get; set; }

        public string? IdChild { get; set; }

        public string? Fullname { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public int? ParentId { get; set; }
    }
}
