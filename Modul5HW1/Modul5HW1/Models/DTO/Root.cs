namespace Modul5HW1.Models.DTO
{
    public class Root
    {
        public int Page { get; set; }
        public int Per_Page { get; set; }
        public int Total { get; set; }
        public int Total_Pages { get; set; }
        public User? User { get; set; }
        public Resource? Resource { get; set; }
        public Support? Support { get; set; }
    }
}
