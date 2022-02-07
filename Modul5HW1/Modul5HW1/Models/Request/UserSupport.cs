using Modul5HW1.Models.DTO;

namespace Modul5HW1.Models.Request
{
    public class UserSupport
    {
        public User Data { get; set; } = null!;
        public Support Support { get; set; } = null!;
    }
}
