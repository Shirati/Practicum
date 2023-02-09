namespace WebAPI.Models
{
    public class UserModel
    {
        public int NumUser { get; set; }

        public string? IdUser { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public DateTime? Date { get; set; }

        public string? MaleOrFemale { get; set; }

        public string? Hmo { get; set; }
    }
}
