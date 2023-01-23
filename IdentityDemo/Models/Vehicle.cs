namespace IdentityDemo.Models
{
#nullable disable
    public class Vehicle
    {
        public int Id { get; set; }
        public string  Name { get; set; }
        public Member Member { get; set; }
        public string MemberId { get; set; }

    }
}