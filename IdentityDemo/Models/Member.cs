using Microsoft.AspNetCore.Identity;
namespace IdentityDemo.Models
{
#nullable disable
    public class Member : IdentityUser
    {
        public bool  IsPro { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; }
    }
}
