using System.ComponentModel.DataAnnotations;

namespace JobSeekerWebApi.Model
{
    public class LocalUser1
    {
       
        public int Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
