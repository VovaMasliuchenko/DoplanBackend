using Microsoft.AspNetCore.Identity;

namespace Doplan.Data.Entities
{
    public class User : IdentityUser
    {
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
        public List<TaskToDo> todoList { get; set; }
    }
}
